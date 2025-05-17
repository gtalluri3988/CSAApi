using AutoMapper;
using DB.EFModel;
using DB.Entity;
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

                var residents = await query
                    .Select(x => new ResidentDTO
                    {
                        BlockNo = x.BlockNo,
                        HouseNo = x.HouseNo,
                        RoadNo = x.RoadNo,
                        Level = x.Level
                    })
                    .ToListAsync();

                return residents;
            }
            catch (Exception)
            {
                return null;
            }
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


    }
}
