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
    public class ComplaintRepository : RepositoryBase<ComplaintDetail, ComplaintDTO>, IComplaintRepository
    {
        public ComplaintRepository(CSADbContext context, IMapper mapper) : base(context, mapper) { }


        public async Task<IEnumerable<ComplaintDTO>> GetAllComplaintsAsync()
        {
            var Visitors = await _context.ComplaintDetail.Include(c => c.ComplaintStatus)
                .Include(c => c.ComplaintType).Include(c=>c.Resident).ToListAsync();
            return _mapper.Map<IEnumerable<ComplaintDTO>>(Visitors);
        }

    }
}
