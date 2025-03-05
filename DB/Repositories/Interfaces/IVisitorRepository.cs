using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories.Interfaces
{
    public interface IVisitorRepository
    {

        Task<IEnumerable<VisitorAccessDetailsDTO>> GetAllAsync();
        Task<VisitorAccessDetailsDTO> GetByIdAsync(int id);
        Task<VisitorAccessDetailsDTO> AddAsync(VisitorAccessDetailsDTO dto);
        Task UpdateAsync(int id, VisitorAccessDetailsDTO dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<VisitorAccessDetailsDTO>> GetAllVisitorsAsync();
    }
}
