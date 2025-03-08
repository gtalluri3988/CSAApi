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
    public class FacilityController : AuthorizedCSABaseAPIController
    {
        private readonly IFacilityService _facilityService;
        private readonly ICurrentUserService _currentUserService;

        public FacilityController(IFacilityService facilityService,
            ICurrentUserService currentUserService, 
            IUserService userService,
            ILogger<ResidentController> logger)
            : base(userService, logger)
        {
            _currentUserService = currentUserService;
            _facilityService = facilityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFacility()
        {
            var Facilities = await _facilityService.GetAllFacilityAsync();
            return Ok(Facilities);
        }

        [HttpGet]
        public async Task<IActionResult> GetFacilityById(int id)
        {
            var facility = await _facilityService.GetFacilityByIdAsync(id);
            if (facility == null)
                return NotFound();
            return Ok(facility);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFacility(FacilityDTO dto)
        {
            var createdVisitor = await _facilityService.CreateFacilityAsync(dto);
            return CreatedAtAction(nameof(GetFacilityById), new { id = createdVisitor.Id }, createdVisitor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFacility(int id, FacilityDTO dto)
        {
            await _facilityService.UpdateFacilityAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacility(int id)
        {
            await _facilityService.DeleteFacilityAsync(id);
            return NoContent();
        }
    }
}
