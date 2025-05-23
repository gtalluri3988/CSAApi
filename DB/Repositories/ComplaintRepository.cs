using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Migrations;
using DB.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class ComplaintRepository : RepositoryBase<ComplaintDetail, ComplaintDTO>, IComplaintRepository
    {
        public ComplaintRepository(CSADbContext context, IMapper mapper,IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor) { }


        public async Task<IEnumerable<ComplaintDTO>> GetAllComplaintsAsync()
        {
            int communityId = await GetUserCommunity();
            var query = _context.ComplaintDetail
                .Include(c => c.ComplaintStatus)
                .Include(c => c.ComplaintType)
                .Include(x => x.Resident)
                .AsQueryable();
            if (communityId != 0)
            {
                query = query.Where(c => c.Resident.CommunityId == communityId);
            }
            var complaints = await query.ToListAsync();
            var complaintsDtos = _mapper.Map<List<ComplaintDTO>>(complaints);
            foreach (var dto in complaintsDtos)
            {
                if (dto.Resident != null)
                {
                    var community = await _context.Community
                        .Where(x => x.Id == dto.Resident.CommunityId)
                        .FirstOrDefaultAsync();
                    dto.CommunityName = community?.CommunityName;
                }
            }
            return complaintsDtos;
        }
        public async Task<ComplaintDTO> GetComplaintByComplaintIdAsync(int complaintId)
        {
            var Complaint = await _context.ComplaintDetail.Include(c => c.Resident).Include(x=>x.ComplaintPhotos).FirstOrDefaultAsync();
            if (Complaint != null)
            {
                foreach (var res in Complaint.ComplaintPhotos)
                {
                    var image = res.ImageGuid == null ? "" : res.ImageGuid;
                    var matchingFiles = Directory.GetFiles(@"C:\Uploads\")
                                     .Where(f => Path.GetFileName(f)
                                     .Contains(image, StringComparison.OrdinalIgnoreCase))
                                     .ToList();
                    byte[] imageBytes = System.IO.File.ReadAllBytes(matchingFiles[0].ToString());
                    string base64String = Convert.ToBase64String(imageBytes);
                    res.Preview = "data:image/" + Path.GetExtension(matchingFiles[0].ToString()) + ";base64," + base64String;
                    res.Name = Path.GetFileName(matchingFiles[0].ToString());
                }
            }
            return _mapper.Map<ComplaintDTO>(Complaint);
        }

        public async Task UpdateComplaintAsync(int complaintId, ComplaintDTO complaint, List<IFormFile> photos)
        {
            var entity = await _context.ComplaintDetail
                               // If related data needs updating
                               .FirstOrDefaultAsync(c => c.Id == complaintId);
            if (entity != null)
            {
                entity.Description=complaint.Description;
                entity.SecurityRemarks = complaint.SecurityRemarks;
                entity.ComplaintStatusId = complaint.ComplaintStatusId;
                entity.UpdatedDate = DateTime.Now;

                if (complaint.ComplaintPhotos != null)
                {
                    _context.ComplaintPhotos.RemoveRange(_context.ComplaintPhotos.Where(p => p.ComplaintDetailId == complaintId));
                    await _context.SaveChangesAsync();
                    foreach (var item in complaint.ComplaintPhotos)
                    {
                        ComplaintPhotos photo = new ComplaintPhotos();
                        var base64Data = item.Preview == null ? "" : item.Preview.Split(',').Last();
                        var imageBytes = Convert.FromBase64String(base64Data);
                        var fileName = $"{Guid.NewGuid()}.png";
                        string drivePath = @"C:\Uploads\";

                        // Ensure the directory exists
                        if (!Directory.Exists(drivePath))
                        {
                            Directory.CreateDirectory(drivePath);
                        }
                        var filePath = Path.Combine(drivePath, fileName);
                        System.IO.File.WriteAllBytes(filePath, imageBytes);
                        var fileUrl = $"/uploads/{fileName}";
                        photo.ImageGuid = fileName;
                        photo.ComplaintDetailId = entity.Id;
                        photo.Name = "";
                        photo.Preview = "";
                        entity.ComplaintPhotos.Add(photo);

                    }
                }
                if (photos != null)
                {
                    foreach (var file in photos)
                    {
                        if (file.Length > 0)
                        {
                            using var memoryStream = new MemoryStream();
                            await file.CopyToAsync(memoryStream);
                            var fileBytes = memoryStream.ToArray();
                            string base64String = Convert.ToBase64String(fileBytes);
                            ComplaintPhotos photo = new ComplaintPhotos();
                            var imageBytes = Convert.FromBase64String(base64String);
                            var fileName = $"{Guid.NewGuid()}.png";
                            string drivePath = @"C:\Uploads\";
                            // Ensure the directory exists
                            if (!Directory.Exists(drivePath))
                            {
                                Directory.CreateDirectory(drivePath);
                            }
                            var filePath = Path.Combine(drivePath, fileName);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);
                            var fileUrl = $"/uploads/{fileName}";
                            photo.ImageGuid = fileName;
                            photo.ComplaintDetailId = entity.Id;
                            photo.Name = "";
                            photo.Preview = "";
                            entity.ComplaintPhotos.Add(photo);
                        }
                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ComplaintDTO> CreateComplaintAsync(ComplaintDTO dto)
        {
            var entity = _mapper.Map<EFModel.ComplaintDetail>(dto);
            _context.ComplaintDetail.Add(entity);
            entity.ComplaintPhotos.Clear();


            if (entity != null && dto.ComplaintPhotos != null)
            {
                foreach (var item in dto.ComplaintPhotos)
                {
                    ComplaintPhotos photo = new ComplaintPhotos();
                    var base64Data = item.Preview == null ? "" : item.Preview.Split(',').Last();
                    var imageBytes = Convert.FromBase64String(base64Data);
                    var fileName = $"{Guid.NewGuid()}.png";
                    string drivePath = @"C:\Uploads\";

                    // Ensure the directory exists
                    if (!Directory.Exists(drivePath))
                    {
                        Directory.CreateDirectory(drivePath);
                    }
                    var filePath = Path.Combine(drivePath, fileName);
                    System.IO.File.WriteAllBytes(filePath, imageBytes);
                    var fileUrl = $"/uploads/{fileName}";
                    photo.ImageGuid = fileName;
                    photo.ComplaintDetailId = entity.Id;
                    photo.Name = "";
                    photo.Preview = "";
                    //_context.FacilityPhoto.Add(photo);
                    entity.ComplaintPhotos.Add(photo);
                }

            }
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id);
        }

        public async Task<IEnumerable<ComplaintDTO>> GetAllComplaintsByCommunityAsync(int communityId)
        {
            var complaints = await _context.ComplaintDetail.Include(c => c.ComplaintStatus)
                .Include(c => c.ComplaintType).Include(x => x.Resident).ToListAsync();
            complaints = complaints
    .Where(x => x.Resident != null && x.Resident.CommunityId == communityId)
    .ToList();
            var complaintsDtos = _mapper.Map<List<ComplaintDTO>>(complaints);
            // Attach PaymentStatus manually
            foreach (var dto in complaintsDtos)
            {
                if (dto.Resident != null)
                {
                    var CommunityName = _context.Community.Where(x => x.Id == dto.Resident.CommunityId).FirstOrDefault();
                    dto.CommunityName = CommunityName?.CommunityName;
                }
            }
            return _mapper.Map<IEnumerable<ComplaintDTO>>(complaintsDtos);
        }

    }
}
