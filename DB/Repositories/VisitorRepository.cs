using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace DB.Repositories
{
    public class VisitorRepository : RepositoryBase<VisitorAccessDetails, VisitorAccessDetailsDTO>, IVisitorRepository
    {
        public VisitorRepository(CSADbContext context, IMapper mapper,IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor) { }


        public async Task<IEnumerable<VisitorAccessDetailsDTO>> GetAllVisitorsAsync()
        {
            int communityId = await GetUserCommunity();
            var query = _context.VisitorAccessDetails
                .Include(c => c.VisitorAccessType)
                .Include(x => x.Community)
                .AsQueryable();

            if (communityId != 0)
            {
                query = query.Where(v => v.CommunityId == communityId);
            }

            var visitors = await query.OrderByDescending(x => x.Id).ToListAsync();
            return _mapper.Map<IEnumerable<VisitorAccessDetailsDTO>>(visitors);
        }

        public async Task<IEnumerable<VisitorAccessDetailsDTO>> GetAllVisitorsByCommunityAsync(int communityId)
        {
            var Visitors = await _context.VisitorAccessDetails.Where(x=>x.CommunityId== communityId).Include(c => c.VisitorAccessType).Include(x => x.Community).OrderByDescending(x => x.Id).ToListAsync();
            return _mapper.Map<IEnumerable<VisitorAccessDetailsDTO>>(Visitors);
        }
        public async Task<IEnumerable<VisitorAccessDetailsDTO>> SearchVisitorsByCommunityIdAsync(VisitorAccessDetailsDTO searchModel)
        {
            int communityId = await GetUserCommunity();

            var query = _context.VisitorAccessDetails
                .Include(c => c.VisitorAccessType)
                .Include(x => x.Community)
                .AsQueryable();

            if (communityId != 0)
            {
                query = query.Where(v => v.CommunityId == communityId);
            }

            // Apply filters based on provided values
            if (!string.IsNullOrEmpty(searchModel.DateFrom))
            {
                var fromDate =Convert.ToDateTime(searchModel.DateFrom);
                query = query.Where(r => r.EntryTime >= fromDate);
            }

            if (!string.IsNullOrEmpty(searchModel.DateTo))
            {
                // Include entire day by setting time to 23:59:59
                var toDate = Convert.ToDateTime(searchModel.DateTo);
                query = query.Where(r => r.ExitTime <= toDate);
            }

            if ( searchModel.VisitorAccessTypeId != 0)
            {
                query = query.Where(r => r.VisitorAccessTypeId == searchModel.VisitorAccessTypeId);
            }
            var visitors = await query.ToListAsync();
            if (!string.IsNullOrWhiteSpace(searchModel.Status))
            {
                visitors = visitors.Where(v =>
                {
                    var computedStatus = v.EntryTime != null && v.ExitTime != null ? "Exit" : "Entry";
                    return computedStatus.Equals(searchModel.Status, StringComparison.OrdinalIgnoreCase);
                }).ToList();
            }

            
            var visitorDtos = _mapper.Map<List<VisitorAccessDetailsDTO>>(visitors);

            return visitorDtos;
        }



    }


}
