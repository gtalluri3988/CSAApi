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
    public class ResidentAccessHistoryService : IResidentAccessHistoryService
    {
        private readonly IResidentAccessHistoryRepository _residentAccessHistoryRepository;

        public ResidentAccessHistoryService(IResidentAccessHistoryRepository residentAccessHistoryRepository)
        {
            _residentAccessHistoryRepository = residentAccessHistoryRepository;

        }
        

        public async Task<IEnumerable<ResidentAccessHistoryDTO>> GetAllResidentAccessHistoryAsync(int? communityId,bool isCSAAdmin)
        {
            return await _residentAccessHistoryRepository.GetAllResidentAccessHistoryAsync(communityId, isCSAAdmin);
        }

        Task<ResidentAccessHistoryDTO> IResidentAccessHistoryService.GetResidentAccessHistoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IResidentAccessHistoryService.SaveResidentAccessHistoryAsync(ResidentAccessHistoryDTO dto)
        {
            throw new NotImplementedException();
        }

        Task IResidentAccessHistoryService.UpdateResidentAccessHistoryAsync(int id, ResidentAccessHistoryDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
