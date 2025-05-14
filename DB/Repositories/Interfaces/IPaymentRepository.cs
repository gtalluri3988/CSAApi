using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<PaymentDTO>> GetAllAsync();
        Task<PaymentDTO> GetByIdAsync(int id);
        Task<PaymentDTO> AddAsync(PaymentDTO dto);
        Task UpdateAsync(int id, PaymentDTO dto);
        Task DeleteAsync(int id);
        Task UpdatePaymentAsync(int paymentId, PaymentDTO dto);

        Task<IEnumerable<PaymentDTO>> GetAllPaymentAsync();
        Task<PaymentDTO> GetPaymentByIdAsync(int id);
        Task<PaymentDTO> AddPaymentAsync(PaymentDTO dto);
        Task<double> GetMaintanenceFeeTotalByPaymentType(int communityId, int paymentTypeId, bool includeCommunityId=false);
    }
}
