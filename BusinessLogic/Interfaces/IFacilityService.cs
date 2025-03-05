using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IFacilityService
    {
        Task<IEnumerable<FacilityDTO>> GetAllFacilityAsync();
        Task<FacilityDTO> GetFacilityByIdAsync(int id);
        Task<FacilityDTO> CreateFacilityAsync(FacilityDTO dto);
        Task UpdateFacilityAsync(int id, FacilityDTO dto);
        Task DeleteFacilityAsync(int id);
    }
}
