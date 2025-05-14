using BusinessLogic.Interfaces;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;

        }
        public async Task<PaymentDTO> CreatePaymentAsync(PaymentDTO dto)
        {
            return await _paymentRepository.AddPaymentAsync(dto);
        }

        public async Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync()
        {
            return await _paymentRepository.GetAllPaymentAsync();
        }

        public async Task<PaymentDTO> GetPaymentByIdAsync(int paymentId)
        {
            return await _paymentRepository.GetPaymentByIdAsync(paymentId);
        }

        public async Task<double> GetMaintanenceFeeTotalByCommunity(int communityId, int paymentTypeId, bool includeCommunityId = false)
        {
            return await _paymentRepository.GetMaintanenceFeeTotalByPaymentType(communityId,paymentTypeId, includeCommunityId);
        }

        public async Task UpdatePaymentAsync(int id, PaymentDTO dto)
        {
            await _paymentRepository.UpdatePaymentAsync(id,dto);
        }


    }
}
