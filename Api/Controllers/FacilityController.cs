using BusinessLogic.Interfaces;
using DB.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService _facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFacility()
        {
            var Visitors = await _facilityService.GetAllFacilityAsync();
            return Ok(Visitors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacilityById(int id)
        {
            var visitor = await _facilityService.GetFacilityByIdAsync(id);
            if (visitor == null)
                return NotFound();
            return Ok(visitor);
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
