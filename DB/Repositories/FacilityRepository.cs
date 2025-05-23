using AutoMapper;
using Azure.Core;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers.Text;
using System.Net.NetworkInformation;

namespace DB.Repositories
{
    public class FacilityRepository : RepositoryBase<Facility, FacilityDTO>, IFacilityRepository
    {
        
        public FacilityRepository(CSADbContext context, IMapper mapper,IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor) { }


        public async Task<IEnumerable<FacilityDTO>> GetAllFacilitiesAsync()
        {
            int communityId = await GetUserCommunity();
            var query = _context.Facility
                .Include(c => c.FacilityType)
                .Include(c => c.Community)
                .AsQueryable();
            if (communityId != 0)
            {
                query = query.Where(f => f.CommunityId == communityId);
            }
            var facilities = await query.ToListAsync();
            return _mapper.Map<IEnumerable<FacilityDTO>>(facilities);
        }

        public async Task<IEnumerable<FacilityDTO>> SearchFacilitiesAsync(int communityId,int facilityTypeId)
        {
            var Facilities = await _context.Facility.Include(c => c.FacilityType).Include(x => x.Community).Where(x =>
        (facilityTypeId == 0 || x.FacilityTypeId == facilityTypeId) &&
        (communityId == 0 || x.CommunityId == communityId)).ToListAsync();
            return _mapper.Map<IEnumerable<FacilityDTO>>(Facilities);
        }

        public async Task<FacilityDTO> CreateFacilityAsync(FacilityDTO dto)
        {
            var entity = _mapper.Map<EFModel.Facility>(dto);
            _context.Facility.Add(entity);
            entity.FacilityPhotos.Clear();
            
            
            if (entity != null && dto.FacilityPhotos!=null)
            {
                foreach (var item in dto.FacilityPhotos)
                {
                    FacilityPhoto photo = new FacilityPhoto();
                    var base64Data =item.Preview== null?"": item.Preview.Split(',').Last();
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
                    photo.FacilityId=entity.Id;
                    photo.Name = "";
                    photo.Preview = "";
                    //_context.FacilityPhoto.Add(photo);
                    entity.FacilityPhotos.Add(photo);
                }
               
            }
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id);
        }

        public async Task<FacilityDTO> GetAllFacilityByIdAsync(int id)
        {
            var Facility = await _context.Facility.Where(x=>x.Id==id).Include(c => c.FacilityType).Include(x => x.Community).Include(x=>x.FacilityPhotos).FirstOrDefaultAsync();
            if (Facility != null)
            {
               foreach (var res in Facility.FacilityPhotos) {
                    var image = res.ImageGuid ==null ? "" : res.ImageGuid;
                    var matchingFiles = Directory.GetFiles(@"C:\Uploads\")
                                     .Where(f => Path.GetFileName(f)
                                     .Contains(image, StringComparison.OrdinalIgnoreCase))
                                     .ToList();
                    byte[] imageBytes = System.IO.File.ReadAllBytes(matchingFiles[0].ToString());
                    string base64String = Convert.ToBase64String(imageBytes);
                    res.Preview = "data:image/"+ Path.GetExtension(matchingFiles[0].ToString())+";base64,"+base64String;
                    res.Name = Path.GetFileName(matchingFiles[0].ToString());
                }
            }
            return _mapper.Map<FacilityDTO>(Facility);
        }

        public async Task UpdateFacilityAsync(int facilityId, FacilityDTO facility)
        {

            var entity = await _context.Facility
                                // If related data needs updating
                               .FirstOrDefaultAsync(c => c.Id == facilityId);
            if (entity != null)
            {
                entity.FacilityDetails = facility.FacilityDetails;
                entity.UpdatedDate = DateTime.Now;
                entity.Rate = facility.Rate;
                entity.FacilityLocation = facility.FacilityLocation;
                entity.FacilityName = facility.FacilityName;
                entity.FacilityTypeId = facility.FacilityTypeId;

               
                if (facility.FacilityPhotos != null)
                {
                    _context.FacilityPhoto.RemoveRange(_context.FacilityPhoto.Where(p => p.FacilityId == facilityId));
                    await _context.SaveChangesAsync();
                    foreach (var item in facility.FacilityPhotos)
                    {
                        FacilityPhoto photo = new FacilityPhoto();
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
                        photo.FacilityId = entity.Id;
                        photo.Name = "";
                        photo.Preview = "";
                        entity.FacilityPhotos.Add(photo);

                    }
                }
            }
            await _context.SaveChangesAsync();

        }
    }
}
