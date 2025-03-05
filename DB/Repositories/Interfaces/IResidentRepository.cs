using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories.Interfaces
{
    public interface IResidentRepository
    {

        Task<IEnumerable<ResidentDTO>> GetAllAsync();
        Task<ResidentDTO> GetByIdAsync(int id);
        Task<ResidentDTO> AddAsync(ResidentDTO dto);
        Task UpdateAsync(int id, ResidentDTO dto);
        Task DeleteAsync(int id);

        Task<IEnumerable<ResidentDTO>> GetAllResidentsByCommunityIdAsync(int communityId);
        Task<ResidentDTO> GetResidentsByResidentIdAsync(int residentId);

        Task<ResidentDTO> SaveResidentAsync(ResidentDTO resident);
        Task UpdateResidenAsync(int residentId, ResidentDTO resident);
    }
}
