using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IComplaintService
    {
        Task<IEnumerable<ComplaintDTO>> GetAllComplaintAsync();
        Task<ComplaintDTO> GetComplaintByIdAsync(int id);
        Task<ComplaintDTO> CreateComplaintAsync(ComplaintDTO dto);
        Task UpdateComplaintAsync(int id, ComplaintDTO dto);
        Task DeleteComplaintAsync(int id);
    }
}
