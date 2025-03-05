using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DB.Repositories
{
    public class CommunityRepository: RepositoryBase<Community, CommunityDTO>, ICommunityRepository
    {
        public CommunityRepository(CSADbContext context,IMapper mapper) : base(context, mapper) { }
        public async Task<List<Community>?> GetCommunityListAsync()
        {
            return await _context.Community.ToListAsync();
        }
        public async Task<List<CommunityType>> GetCommunityTypeAsync()
        {
            return await _context.CommunityType.ToListAsync();
        }

        public async Task<IEnumerable<CommunityDTO>> GetAllWithStatesAsync()
        {
            var complaints = await _context.Community.Include(c => c.State).ToListAsync();
            return _mapper.Map<IEnumerable<CommunityDTO>>(complaints);
        }

        public async Task<CommunityDTO> SaveCommunityAsync(CommunityDTO community)
        {
            var entity = _mapper.Map<EFModel.Community>(community);
            _context.Community.Add(entity);           
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id);
        }

        public async Task UpdateCommunityAsync(int communityId,CommunityDTO community)
        {
           
            var entity = await _context.Community
                               .Include(c => c.VisitorParkingCharges) // If related data needs updating
                               .FirstOrDefaultAsync(c => c.Id == communityId);
            if (entity != null)
            {
                entity.Address = community.Address;
                entity.UpdatedDate = DateTime.Now;
                entity.CityName= community.CityName;    
                entity.PICName= community.PICName;  
                entity.CommunityName = community.CommunityName; 
                entity.CommunityTypeId= community.CommunityTypeId;
                entity.StateId = community.StateId;
                entity.FeesMonthly= community.FeesMonthly;
                entity.GracePeriod= community.GracePeriod;
                entity.NoOfParkingLot= community.NoOfParkingLot;
                entity.NoOfUnits= community.NoOfUnits;
                entity.PICMobile= community.PICMobile;
                entity.PICEmail= community.PICEmail;

                if (community.VisitorParkingCharges != null)
                {
                    entity.VisitorParkingCharges.Clear();
                    foreach (var charge in community.VisitorParkingCharges)
                    {
                        entity.VisitorParkingCharges.Add(new VisitorParkingCharge
                        {
                            ChargeTypeId = charge.ChargeTypeId,
                            Amount = charge.Amount,
                            NoOfVistorParkingLot = charge.NoOfVistorParkingLot,
                            Status = charge.Status
                        });
                    }
                }
            }
            await _context.SaveChangesAsync();
            
        }
        public async Task<CommunityDTO> GetCommunityByIdAsync(int id)
        {
            var complaints = await _context.Community.Include(c => c.State).Include(c=>c.VisitorParkingCharges).Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<CommunityDTO>(complaints);
        }

       
        public async Task<List<CommunityResidentCountDto>> GetAllCommunityWithResidentListAsync()
        {
            return await _context.Community
                .Select(c => new CommunityResidentCountDto
                {
                    Id=c.Id,
                    CommunityId = c.CommunityId,
                    CommunityName = c.CommunityName,
                    ResidentCount = c.Residents.Count() // Count of residents
                })
                .ToListAsync();
        }


        public async Task<List<Community>> GetCommunitiesWithResidentsAsync()
        {
            return await _context.Community
                .Include(c => c.Residents)  // Include Residents
                .ToListAsync();
        }

        public async Task<Community?> GetCommunityByIdWithResidentsAsync(int id)
        {
            return await _context.Community
                .Where(c => c.Id == id)
                .Include(c => c.Residents)  // Load residents for this community
                .FirstOrDefaultAsync();
        }
    }
}
