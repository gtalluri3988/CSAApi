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
    public class ResidentAccessHistoryRepository : RepositoryBase<ResidentAccessHistory, ResidentAccessHistoryDTO>, IResidentAccessHistoryRepository
    {
        public ResidentAccessHistoryRepository(CSADbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) :
            base(context, mapper, httpContextAccessor)
        {
        }

        public async Task<IEnumerable<ResidentAccessHistoryDTO>> GetAllResidentAccessHistoryAsync(int? communityId, bool isCSAAdmin)
        {
            int community = await GetUserCommunity();
            var query = _context.ResidentAccessHistory
                .Include(c => c.Resident)
                .AsQueryable();

            if (communityId != 0)
            {
                query = query.Where(r => r.Resident.CommunityId == community);
            }

            var residentAccessHistory = await query.ToListAsync();
            var dtoList = _mapper.Map<List<ResidentAccessHistoryDTO>>(residentAccessHistory);

            var currentTime = DateTime.UtcNow;

            foreach (var dto in dtoList)
            {
                if (dto.ValidFrom <= currentTime && dto.ValidTo >= currentTime)
                {
                    dto.Status = "Valid";
                }
                else
                {
                    dto.Status = "Expired";
                }
            }

            return dtoList;
        }

        public async Task<ResidentAccessHistoryDTO> GetResidentAccessHistoryByIdAsync(int? AccessId)
        {
            var query =await _context.ResidentAccessHistory.Where(x => x.Id == AccessId)
                .Include(c => c.Resident).FirstOrDefaultAsync();
            return _mapper.Map<ResidentAccessHistoryDTO>(query);
        }

        public async Task<ResidentAccessHistoryDTO> SaveResidentAccessHistoryAsync(ResidentAccessHistoryDTO resident)
        {
            var ResidentId=_context.Resident.Where(x=>x.CommunityId==resident.CommunityId && x.RoadNo==resident.RoadNo
            && x.BlockNo == resident.BlockNo && x.Level == resident.LevelNo && x.HouseNo==resident.HouseNo).Select(x=>x.Id).FirstOrDefault();
            resident.ResidentId = ResidentId;
            var entity = _mapper.Map<EFModel.ResidentAccessHistory>(resident);
            _context.ResidentAccessHistory.Add(entity);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id);
        }

    }
}
