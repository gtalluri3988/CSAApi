using AutoMapper;
using DB.EFModel;
using DB.Entity;
using DB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DB.Repositories
{
    public class PaymentRepository : RepositoryBase<ResidencePaymentDetails, PaymentDTO>, IPaymentRepository
    {

       
        public PaymentRepository(CSADbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : 
            base(context, mapper,httpContextAccessor) {

           
        }
        
        public async Task<PaymentDTO> AddPaymentAsync(PaymentDTO dto)
        {
            var entity = _mapper.Map<EFModel.ResidencePaymentDetails>(dto);
            _context.ResidencePaymentDetails.Add(entity);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id);
        }

        public async Task<IEnumerable<PaymentDTO>> GetAllPaymentAsync()
        {
            var Payments = await _context.ResidencePaymentDetails.Include(c => c.PaymentStatus).Include(c=>c.PaymentType).Include(c=>c.resident).ToListAsync();
            return _mapper.Map<IEnumerable<PaymentDTO>>(Payments);
        }

        public async Task<PaymentDTO> GetPaymentByIdAsync(int id)
        {
            var residents = await _context.ResidencePaymentDetails.Where(x => x.Id == id).Include(c => c.PaymentStatus).Include(c => c.PaymentType).Include(c => c.resident).FirstOrDefaultAsync();
            return _mapper.Map<PaymentDTO>(residents);
        }

        public async Task UpdatePaymentAsync(int payId, PaymentDTO payment)
        {
            var entity = await _context.ResidencePaymentDetails.FirstOrDefaultAsync(c => c.Id == payId);

            if (entity != null && payment != null)
            {
                //entity.PaymentStatus = payment.PaymentStatus;
                //entity.PaymentDate = role.Status;
                //entity.UpdatedDate = DateTime.Now;
                entity.Amount = payment.Amount;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            { }
        }

        public async Task<double> GetMaintanenceFeeTotalByPaymentType(int communityId, int paymentTypeId, bool includeCommunityId = false)
        {
            
            if (includeCommunityId)
            {
                var totalAmounts = await _context.ResidencePaymentDetails
                             .Where(x => x.resident != null && x.resident.CommunityId == communityId && x.PaymentTypeId == paymentTypeId)
                             .SumAsync(x => x.Amount);
                return totalAmounts;
            }
            else
            {
                var totalAmounts = await _context.ResidencePaymentDetails
                            .Where(x => x.resident != null &&  x.PaymentTypeId == paymentTypeId)
                            .SumAsync(x => x.Amount);
                return totalAmounts;
            }
        }

    }
}
