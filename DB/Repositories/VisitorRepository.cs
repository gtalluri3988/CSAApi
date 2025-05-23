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



    }

    
}
