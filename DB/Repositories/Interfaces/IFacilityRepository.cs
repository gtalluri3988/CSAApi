using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories.Interfaces
{
    public interface IFacilityRepository
    {
        Task<IEnumerable<FacilityDTO>> GetAllAsync();
        Task<FacilityDTO> GetByIdAsync(int id);
        Task<FacilityDTO> AddAsync(FacilityDTO dto);
        Task UpdateAsync(int id, FacilityDTO dto);
        Task DeleteAsync(int id);
    }
}
