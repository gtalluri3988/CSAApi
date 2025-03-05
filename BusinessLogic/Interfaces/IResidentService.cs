using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IResidentService
    {
        Task<IEnumerable<ResidentDTO>> GetAllResidentsByCommunityAsync(int communityId);
        Task<ResidentDTO> GetResidentsByResidentIdAsync(int residentId);
        Task<ResidentDTO> CreateResidentAsync(ResidentDTO dto);
        Task UpdateResidentAsync(int id, ResidentDTO dto);
    }
}
