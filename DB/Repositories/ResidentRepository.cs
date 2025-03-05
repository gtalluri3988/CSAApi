using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
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
        public ResidentRepository(CSADbContext context, IMapper mapper) : base(context, mapper) { }


        public async Task<IEnumerable<ResidentDTO>> GetAllResidentsByCommunityIdAsync(int communityId)
        {
            var residents = await _context.Resident.Include(c => c.State).Where(x => x.CommunityId == communityId).ToListAsync();
            return _mapper.Map<IEnumerable<ResidentDTO>>(residents);
        }

        public async Task<ResidentDTO> SaveResidentAsync(ResidentDTO resident)
        {
            var entity = _mapper.Map<EFModel.Resident>(resident);
            _context.Resident.Add(entity);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id);
        }

        public async Task<ResidentDTO> GetResidentsByResidentIdAsync(int residentId)
        {
            var residents = await _context.Resident.Where(x => x.Id == residentId).Include(x=>x.VehicleDetails).FirstOrDefaultAsync();
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


    }
}
