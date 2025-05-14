using BusinessLogic.Interfaces;
using DB.Entity;
using DB.Repositories.Interfaces;


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

        public async Task UpdateComplaintAsync(int id, ComplaintDTO dto)
        {
            await _complaintRepository.UpdateComplaintAsync(id, dto);
        }

        public async Task DeleteComplaintAsync(int id)
        {
            await _complaintRepository.DeleteAsync(id);
        }
    }
}
