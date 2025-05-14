using DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync();
        Task<PaymentDTO> GetPaymentByIdAsync(int residentId);
        Task<PaymentDTO> CreatePaymentAsync(PaymentDTO dto);
        Task UpdatePaymentAsync(int id, PaymentDTO dto);
        //Task<double> GetTotalMaintanence(int paymentTypeId, int communityId);

        Task<double> GetMaintanenceFeeTotalByCommunity(int communityId, int paymentTypeId, bool includeCommunityId = false);

    }
}
