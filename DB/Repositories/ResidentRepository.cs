using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DB.Migrations.Helpers;
namespace DB.Repositories
{
    public class ResidentRepository : RepositoryBase<Resident, ResidentDTO>, IResidentRepository
    {
        public ResidentRepository(CSADbContext context, IMapper mapper,IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor) { }
        public async Task<IEnumerable<ResidentDTO>> GetAllResidentsByCommunityIdAsync(int communityId)
        {
            //var residents = await _context.Resident.Include(c => c.State).Include(c=>c.ResidencePaymentDetails).Where(x => x.CommunityId == communityId).ToListAsync();
            var currentMonth = DateTime.UtcNow.Month;
            var currentYear = DateTime.UtcNow.Year;
            var residents = await _context.Resident
                .Include(r => r.State)
                .Include(r => r.ResidencePaymentDetails)
                    .ThenInclude(p => p.PaymentStatus)
                .Where(r => r.CommunityId == communityId)
                .ToListAsync();
            // Map all residents
            var residentDtos = _mapper.Map<List<ResidentDTO>>(residents);
            // Attach PaymentStatus manually
            foreach (var dto in residentDtos)
            {
                var entity = residents.First(r => r.Id == dto.Id);
                var payment = entity.ResidencePaymentDetails?
                    .FirstOrDefault(p =>
                        p.PaymentDate.HasValue &&
                        p.PaymentDate.Value.Month == currentMonth &&
                        p.PaymentDate.Value.Year == currentYear);
                dto.PaymentStatus = payment?.PaymentStatus?.Name ?? "Awaiting Payment";
            }
            return residentDtos;
        }
        public async Task<IEnumerable<ResidentDTO>> SearchResidentsByCommunityIdAsync(ResidentDTO searchModel)
        {
            var currentMonth = DateTime.UtcNow.Month;
            var currentYear = DateTime.UtcNow.Year;
            // Start with base query
            var query = _context.Resident
                .Include(r => r.State)
                .Include(r => r.ResidencePaymentDetails)
                    .ThenInclude(p => p.PaymentStatus)
                .Where(r => r.CommunityId == searchModel.CommunityId);
            // Apply filters only if values are provided
            if (!string.IsNullOrWhiteSpace(searchModel.RoadNo))
                query = query.Where(r => r.RoadNo == searchModel.RoadNo);
            if (!string.IsNullOrWhiteSpace(searchModel.BlockNo))
                query = query.Where(r => r.BlockNo == searchModel.BlockNo);
            if (!string.IsNullOrWhiteSpace(searchModel.HouseNo))
                query = query.Where(r => r.HouseNo == searchModel.HouseNo);
            if (!string.IsNullOrWhiteSpace(searchModel.Level))
                query = query.Where(r => r.Level == searchModel.Level);
            var residents = await query.ToListAsync();
            var residentDtos = _mapper.Map<List<ResidentDTO>>(residents);
            foreach (var dto in residentDtos)
            {
                var entity = residents.First(r => r.Id == dto.Id);
                var payment = entity.ResidencePaymentDetails?
                    .FirstOrDefault(p =>
                        p.PaymentDate.HasValue &&
                        p.PaymentDate.Value.Month == currentMonth &&
                        p.PaymentDate.Value.Year == currentYear);
                dto.PaymentStatus = payment?.PaymentStatus?.Name ?? "Awaiting Payment";
            }
            if (!string.IsNullOrWhiteSpace(searchModel.maintainanceFee))
                residentDtos = residentDtos.Where(x => x.PaymentStatus == searchModel.maintainanceFee).ToList();
                return residentDtos;
        }
        public async Task<ResidentDTO> SaveResidentAsync(ResidentDTO resident)
        {
            var entity = _mapper.Map<EFModel.Resident>(resident);
                var residentCheck=_context.Resident.Where(x=>x.RoadNo==resident.RoadNo && x.BlockNo==resident.BlockNo 
                && x.Level == resident.Level && x.HouseNo == resident.HouseNo && x.CommunityId==resident.CommunityId).FirstOrDefault();
                if (residentCheck != null)
                {
                    throw new Exception("Already another resident alloted for this unit");
                }
                entity.RoleId = 5;
                _context.Resident.Add(entity);
                await _context.SaveChangesAsync();
            if (resident != null && !string.IsNullOrWhiteSpace(resident.Email))
            {
                string communityFullName = string.Empty;
                var password = EmailHelper.GenerateRandomPassword();
                var res = _context.Resident.Where(x => x.Id == entity.Id).FirstOrDefault();
                if(res != null)
                {

                    res.Password= password;
                    _context.SaveChanges();
                    var community = _context.Community.Where(x => x.Id == res.CommunityId).FirstOrDefault();
                    if(community != null)
                    {
                        communityFullName = community.CommunityId + "-" + community.CommunityName;
                    }
                }
                
                await SendWelcomeEmailAsync(
                    toEmail: resident.Email,
                    residentFullName: resident.Name ?? "Resident",
                    tempPassword: password,
                    residentPageUrl: "https://103.27.86.226/CSADEV/csa/login",
                    communityFullName
                );
            }
            return await GetByIdAsync(entity.Id);
        }
        public async Task<List<ResidentDTO>> GetResidentsDropdownsAsync(int communityId,string Type)
        {
            try
            {
                IQueryable<Resident> query = _context.Resident;
                if (communityId != 0)
                {
                    query = query.Where(x => x.CommunityId == communityId);
                }
                var residents = (await query
                 .Select(x => new ResidentDTO
                 {
                     BlockNo = x.BlockNo,
                     HouseNo = x.HouseNo,

                     Level = x.Level,
                     RoadNo = x.RoadNo,
                 })
                 .ToListAsync())
                 .OrderBy(x =>
                 {
                     return int.TryParse(x.RoadNo, out var n) ? n : int.MaxValue;
                 })
                 .ToList();
                return residents;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<string>> GetRoardsByCommunityAsync(int communityId)
        {
            IQueryable<Resident> query = _context.Resident;
            if (communityId != 0)
            {
                query = query.Where(x => x.CommunityId == communityId);
            }
           
            var roadList = await query
                .Select(x => x.RoadNo)
                .Distinct()
                .ToListAsync();
            return roadList;
        }
        public async Task<List<string>> GetBlocksByRoadAsync(int communityId, string roadNo)
        {
                IQueryable<Resident> query = _context.Resident;
                if (communityId != 0)
                {
                    query = query.Where(x => x.CommunityId == communityId);
                }
                if (!string.IsNullOrEmpty(roadNo))
                {
                    query = query.Where(x => x.RoadNo == roadNo);
                }
                var blockList = await query
                    .Select(x => x.BlockNo)
                    .Distinct()
                    .ToListAsync();
                return blockList;
        }

        public async Task<List<string>> GetLevelsByRoadAsync(int communityId, string roadNo,string blockNo)
        {
            IQueryable<Resident> query = _context.Resident;
            if (communityId != 0)
            {
                query = query.Where(x => x.CommunityId == communityId);
            }
            if (!string.IsNullOrEmpty(roadNo))
            {
                query = query.Where(x => x.RoadNo == roadNo && x.BlockNo== blockNo);
            }
            var levelList = await query
                .Select(x => x.Level)
                .Distinct()
                .ToListAsync();
            return levelList;
        }

        public async Task<List<string>> GetHouseNosByLevelAsync(int communityId, string roadNo, string blockNo,string level)
        {
            IQueryable<Resident> query = _context.Resident;
            if (communityId != 0)
            {
                query = query.Where(x => x.CommunityId == communityId);
            }
            if (!string.IsNullOrEmpty(roadNo))
            {
                query = query.Where(x => x.RoadNo == roadNo && x.BlockNo == blockNo && x.Level==level);
            }
            var houseList = await query
                .Select(x => x.HouseNo)
                .Distinct()
                .ToListAsync();
            return houseList;
        }



        public async Task<List<string>> GetResidentHierarchyAsync(
        int communityId = 0,
        string roadNo = null,
        string blockNo = null,
        string level = null,
        string targetField = "RoadNo")
        {
            IEnumerable<Resident> query = _context.Resident;

            if (communityId != 0)
                query = query
                        .Where(x => x.CommunityId == communityId)
                        .AsEnumerable() // switch to in-memory
                        .OrderBy(x =>
                        {
                            var str = x.RoadNo ?? "";
                            var digits = str.TakeWhile(char.IsDigit).ToArray();
                            var numPart = new string(digits);
                            return int.TryParse(numPart, out var n) ? n : int.MaxValue;
                        })
                        .ThenBy(x => x.RoadNo)
                        .ToList();

            if (!string.IsNullOrEmpty(roadNo))
            {
                query = query
                        .Where(x => x.RoadNo == roadNo)
                        .AsEnumerable() // switch to in-memory
                        .OrderBy(x =>
                        {
                            var str = x.BlockNo ?? "";
                            var digits = str.TakeWhile(char.IsDigit).ToArray();
                            var numPart = new string(digits);
                            return int.TryParse(numPart, out var n) ? n : int.MaxValue;
                        })
                        .ThenBy(x => x.BlockNo)
                        .ToList();
            }

            if (!string.IsNullOrEmpty(blockNo))
                query = query.Where(x => x.BlockNo == blockNo).AsEnumerable() // switch to in-memory
                        .OrderBy(x =>
                        {
                            var str = x.Level ?? "";
                            var digits = str.TakeWhile(char.IsDigit).ToArray();
                            var numPart = new string(digits);
                            return int.TryParse(numPart, out var n) ? n : int.MaxValue;
                        })
                        .ThenBy(x => x.Level)
                        .ToList();

            if (!string.IsNullOrEmpty(level))
                query = query.Where(x => x.Level == level).AsEnumerable() // switch to in-memory
                        .OrderBy(x =>
                        {
                            var str = x.HouseNo ?? "";
                            var digits = str.TakeWhile(char.IsDigit).ToArray();
                            var numPart = new string(digits);
                            return int.TryParse(numPart, out var n) ? n : int.MaxValue;
                        })
                        .ThenBy(x => x.HouseNo)
                        .ToList();

            return targetField switch
            {
                "RoadNo" => query.Select(x => x.RoadNo).Distinct().ToList(),
                "BlockNo" =>  query.Select(x => x.BlockNo).Distinct().ToList(),
                "Level" =>  query.Select(x => x.Level).Distinct().ToList(),
                "HouseNo" =>  query.Select(x => x.HouseNo).Distinct().ToList(),
                _ => new List<string>()
            };
        }


        public async Task<ResidentDTO> GetResidentsByResidentIdAsync(int residentId)
        {
            var residents = await _context.Resident.Where(x => x.Id == residentId).Include(x=>x.VehicleDetails).FirstOrDefaultAsync();
            return _mapper.Map<ResidentDTO>(residents);
        }
        public  ResidentDTO GetResidentsByEmailPasswordAsync(string Email,string Password)
        {
            var residents =  _context.Resident.Where(x => x.Email == Email && x.Password==Password).FirstOrDefault();
            return _mapper.Map<ResidentDTO>(residents);
        }
        public async Task UpdateResidenAsync(int residentId, ResidentDTO resident)
        {
            var entity = await _context.Resident
                               .Include(c => c.VehicleDetails) // If related data needs updating
                               .FirstOrDefaultAsync(c => c.Id == residentId);
            if (entity != null)
            {
                entity.BlockNo = resident.BlockNo;
                entity.UpdatedDate = DateTime.Now;
                entity.CommunityId = resident.CommunityId;
                entity.Email= resident.Email;
                entity.Name = resident.Name;
                entity.ParkingLotQty = resident.ParkingLotQty;
                entity.HouseNo = resident.HouseNo;
                entity.PhoneNo = resident.PhoneNo;
                entity.LotNo = resident.LotNo;
                entity.Level= resident.Level;
                entity.MaintenenceFeesCost= resident.MaintenenceFeesCost;
                entity.NRIC= resident.NRIC;
                entity.StateId= resident.StateId;
                entity.ParkingLotNos= resident.ParkingLotNos;
                entity.Name= resident.Name;
                if (resident.VehicleDetails != null)
                {
                    entity.VehicleDetails.Clear();
                    foreach (var vehicle in resident.VehicleDetails)
                    {
                        entity.VehicleDetails.Add(new VehicleDetails
                        {
                            ResidentId = vehicle.ResidentId,
                            VehicleNo = vehicle.VehicleNo,
                            VehicleTypeId = vehicle.VehicleTypeId,
                            UpdatedDate = DateTime.Now,
                        });
                    }
                }
            }
            await _context.SaveChangesAsync();
        }
        public async Task<ResidentDTO> GetResidentsByNRICAsync(string nric,int communityId)
        {
            var residents = await _context.Resident.Where(x => x.NRIC == nric && x.CommunityId== communityId).FirstOrDefaultAsync();
            return _mapper.Map<ResidentDTO>(residents);
        }
        public async Task<ResidentDTO> GetResidentsNameandContactByAddresses(string roadNo, string blockNo, string level, string houseNo)
        {
            var residents = await _context.Resident.Where(x => x.RoadNo == roadNo && x.BlockNo == blockNo && x.Level==level && x.HouseNo==houseNo).FirstOrDefaultAsync();
            return _mapper.Map<ResidentDTO>(residents);
        }

        public async Task SendWelcomeEmailAsync(string toEmail, string residentFullName, string tempPassword, string residentPageUrl,string community)
        {
            var fromEmail = "absec.demo@gmail.com";
            var subject = $"Welcome to Community Smart Access - Your Account Has Been Created";
            var body = EmailHelper.GetWelcomeEmailBody(residentFullName, toEmail, tempPassword, residentPageUrl,community);
            using var client = new SmtpClient("smtp.gmail.com") // Replace with your SMTP
            {
                Port = 587,
                Credentials = new NetworkCredential("absec.demo@gmail.com", "qhogkbdwobdoznyx"),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail, "CSA Team"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            try
            {
                mailMessage.To.Add(toEmail);
                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                //throw(ex);
            }
        }
    }
}
