using BusinessLogic.Interfaces;
using DB.Entity;
using DB.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services
{
    public class ComplaintService : IComplaintService
    {

        private readonly IComplaintRepository _complaintRepository;

        public ComplaintService(IComplaintRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        public async Task<IEnumerable<ComplaintDTO>> GetAllComplaintAsync()
        {
            return await _complaintRepository.GetAllComplaintsAsync();
        }

        public async Task<ComplaintDTO> GetComplaintByIdAsync(int id)
        {
            return await _complaintRepository.GetComplaintByComplaintIdAsync(id);
        }

        public async Task<ComplaintDTO> CreateComplaintAsync(ComplaintDTO dto)
        {
            return await _complaintRepository.CreateComplaintAsync(dto);
        }

        public async Task UpdateComplaintAsync(int id, ComplaintDTO dto, List<IFormFile> photos)
        {
            await _complaintRepository.UpdateComplaintAsync(id, dto, photos);
        }

        public async Task DeleteComplaintAsync(int id)
        {
            await _complaintRepository.DeleteAsync(id);
        }
    }
}
