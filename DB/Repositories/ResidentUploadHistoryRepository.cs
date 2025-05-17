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
    
    public class ResidentUploadHistoryRepository : RepositoryBase<ResidentUploadHistory, ResidentUploadHistoryDTO>, IResidentUploadHistoryRepository
    {
        public ResidentUploadHistoryRepository(CSADbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) :
            base(context, mapper, httpContextAccessor)
        {
        }

        public async Task<IEnumerable<ResidentUploadHistoryDTO>> GetAllResidentAccessHistoryAsync(int? communityId, bool isCSAAdmin)
        {
            if (isCSAAdmin)
            {
                var ResidentAccessHistory = await _context.ResidentAccessHistory.Include(c => c.Resident).ToListAsync();
                return _mapper.Map<IEnumerable<ResidentUploadHistoryDTO>>(ResidentAccessHistory);
            }
            else
            {
                var ResidentAccessHistory = await _context.ResidentAccessHistory.Where(x => x.CommunityId == communityId).Include(c => c.Resident).ToListAsync();
                return _mapper.Map<IEnumerable<ResidentUploadHistoryDTO>>(ResidentAccessHistory);
            }
        }

    }
}
