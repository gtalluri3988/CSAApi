using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories.Interfaces
{
    public interface IComplaintRepository
    {
        Task<IEnumerable<ComplaintDTO>> GetAllAsync();
        Task<ComplaintDTO> GetByIdAsync(int id);
        Task<ComplaintDTO> AddAsync(ComplaintDTO dto);
        Task UpdateAsync(int id, ComplaintDTO dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ComplaintDTO>> GetAllComplaintsAsync();
    }
}
