using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Models;
using YourNamespace.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using BusinessLogic.Services;
using DB.Entity;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaymentController : AuthorizedCSABaseAPIController
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly ICommunityService _communityService;
        public readonly IResidentService _residentService;
        public readonly IPaymentService _paymentService;
        public PaymentController(
            ICurrentUserService currentUserService,
            ICommunityService communityService,
            IResidentService residentService,
            IUserService userService,
            IPaymentService paymentService,
            ILogger<PaymentController> logger)
            : base(userService, logger)
        {
            _currentUserService = currentUserService;
            _communityService = communityService;
            _residentService = residentService;
            _paymentService = paymentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            return Ok(await _paymentService.GetAllPaymentsAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetPaymentById(int payId)
        {
            return Ok(await _paymentService.GetPaymentByIdAsync(payId));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePayment(PaymentDTO payment)
        {
            var createdPayment = await _paymentService.CreatePaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = createdPayment.Id }, createdPayment);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePayment(int id, PaymentDTO dto)
        {
            await _paymentService.UpdatePaymentAsync(id, dto);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> TotalMaintanenceAmountByCommunity(int communityId,int paymentTypeId)
        {
            if (IsResidentAdmin())
            {
                var PaymentTotal = await _paymentService.GetMaintanenceFeeTotalByCommunity(communityId, paymentTypeId,includeCommunityId:true);
                var response = new { PaymentTypeId = paymentTypeId, TotalAmount = PaymentTotal.ToString("N2") };
                return Ok(response);
            }
            if(IsCSAAdmin())
            {
                var PaymentTotal = await _paymentService.GetMaintanenceFeeTotalByCommunity(communityId, paymentTypeId);
                var response = new { PaymentTypeId = paymentTypeId, TotalAmount = PaymentTotal.ToString("N2") };
                return Ok(response);
            }
            return NotFound();
        }


    }
}
