using BusinessLogic.Interfaces;
using DB.Entity;
using DB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class VisitorService : IVisitorService
    {

        private readonly IVisitorRepository _visitorRepository;

        public VisitorService(IVisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        public async Task<IEnumerable<VisitorAccessDetailsDTO>> GetAllVisitorsAsync()
        {
            return await _visitorRepository.GetAllVisitorsAsync();
        }

        public async Task<IEnumerable<VisitorAccessDetailsDTO>> GetAllVisitorsByCommunityAsync(int communityId)
        {
            return await _visitorRepository.GetAllVisitorsByCommunityAsync(communityId);
        }

        public async Task<VisitorAccessDetailsDTO> GetVisitorsByIdAsync(int id)
        {
            return await _visitorRepository.GetByIdAsync(id);
        }

        public async Task<VisitorAccessDetailsDTO> CreateVisitorAsync(VisitorAccessDetailsDTO dto)
        {
            return await _visitorRepository.AddAsync(dto);
        }

        public async Task UpdateVisitorAsync(int id, VisitorAccessDetailsDTO dto)
        {
            await _visitorRepository.UpdateAsync(id, dto);
        }

        public async Task DeleteVisitorAsync(int id)
        {
            await _visitorRepository.DeleteAsync(id);
        }
    }
}
