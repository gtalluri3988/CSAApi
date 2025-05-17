using BusinessLogic.Interfaces;
using DB.Entity;
using DB.Repositories;
using DB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ResidentUploadHistoryService : IResidentUploadHistoryService
    {
        private readonly IResidentUploadHistoryRepository _residentUploadHistoryRepository;

        public ResidentUploadHistoryService(IResidentUploadHistoryRepository residentUploadHistoryRepository)
        {
            _residentUploadHistoryRepository = residentUploadHistoryRepository;

        }

        Task<IEnumerable<ResidentUploadHistoryDTO>> IResidentUploadHistoryService.GetAllResidentUploadHistoryAsync()
        {
            throw new NotImplementedException();
        }

        Task<ResidentUploadHistoryDTO> IResidentUploadHistoryService.GetResidentUploadHistoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IResidentUploadHistoryService.SaveResidentUploadHistoryAsync(ResidentUploadHistoryDTO dto)
        {
            throw new NotImplementedException();
        }

        Task IResidentUploadHistoryService.UpdateResidentUploadHistoryAsync(int id, ResidentUploadHistoryDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}


