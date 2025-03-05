using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IVisitorService
    {
        Task<IEnumerable<VisitorAccessDetailsDTO>> GetAllVisitorsAsync();
        Task<VisitorAccessDetailsDTO> GetVisitorsByIdAsync(int id);
        Task<VisitorAccessDetailsDTO> CreateVisitorAsync(VisitorAccessDetailsDTO dto);
        Task UpdateVisitorAsync(int id, VisitorAccessDetailsDTO dto);
        Task DeleteVisitorAsync(int id);
    }
}
