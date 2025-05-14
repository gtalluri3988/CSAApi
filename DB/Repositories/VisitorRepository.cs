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
            var Visitors = await _context.VisitorAccessDetails.Include(c => c.VisitorAccessType).OrderByDescending(x=>x.Id).ToListAsync();
            return _mapper.Map<IEnumerable<VisitorAccessDetailsDTO>>(Visitors);
        }



    }

    
}
