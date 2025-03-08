using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DB.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ComplaintController : AuthorizedCSABaseAPIController
    {
        private readonly IComplaintService _complaintService;
        private readonly ICurrentUserService _currentUserService;

        public ComplaintController(
            IComplaintService complaintService,
            ICurrentUserService currentUserService,
            IUserService userService,
            ILogger<ResidentController> logger)
            : base(userService, logger)
        {
            _currentUserService = currentUserService;
            _complaintService = complaintService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComplaints()
        {
            var Complaints = await _complaintService.GetAllComplaintAsync();
            return Ok(Complaints);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComplaintById(int id)
        {
            var visitor = await _complaintService.GetComplaintByIdAsync(id);
            if (visitor == null)
                return NotFound();
            return Ok(visitor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComplaint(ComplaintDTO dto)
        {
            var createdVisitor = await _complaintService.CreateComplaintAsync(dto);
            return CreatedAtAction(nameof(GetComplaintById), new { id = createdVisitor.Id }, createdVisitor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComplaint(int id, ComplaintDTO dto)
        {
            await _complaintService.UpdateComplaintAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            await _complaintService.DeleteComplaintAsync(id);
            return NoContent();
        }
    }
}
