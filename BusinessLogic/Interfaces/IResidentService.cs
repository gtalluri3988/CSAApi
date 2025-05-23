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
        Task<ResidentDTO> GetResidentsByNRICAsync(string nric,int communityId);
        Task<IEnumerable<ResidentDTO>> GetAllResidentsByCommunityDropdownAsync(int communityId, string Type);
        Task<ResidentDTO> GetResidentsNameandContactByAddresses(string roadNo, string blockNo, string level, string houseNo);
        Task<IEnumerable<ResidentDTO>> SearchResidentsByCommunityIdAsync(ResidentDTO search);

        Task<IEnumerable<string>> GetResidentHierarchyAsync(int communityId, string roadNo, string blockNo, string level, string targetField);
    }
}
