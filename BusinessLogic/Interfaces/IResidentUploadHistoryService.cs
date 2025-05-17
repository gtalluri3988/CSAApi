using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IResidentUploadHistoryService
    {
        Task UpdateResidentUploadHistoryAsync(int id, ResidentUploadHistoryDTO dto);

        Task SaveResidentUploadHistoryAsync(ResidentUploadHistoryDTO dto);

        Task<ResidentUploadHistoryDTO> GetResidentUploadHistoryByIdAsync(int id);

        Task<IEnumerable<ResidentUploadHistoryDTO>> GetAllResidentUploadHistoryAsync();
    }
}

