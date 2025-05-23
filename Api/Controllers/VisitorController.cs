using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DB.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorService _visitorService;

        public VisitorController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVisitors()
        {
            try
            {
                
                return Ok(await _visitorService.GetAllVisitorsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVisitorsByCommunityId(int communityId)
        {
            try
            {

                return Ok(await _visitorService.GetAllVisitorsByCommunityAsync(communityId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetVisitorById(int id)
        {
            var visitor = await _visitorService.GetVisitorsByIdAsync(id);
            if (visitor == null)
                return NotFound();
            return Ok(visitor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisitor(VisitorAccessDetailsDTO dto)
        {
            try
            {
                var createdVisitor = await _visitorService.CreateVisitorAsync(dto);
                return CreatedAtAction(nameof(GetVisitorById), new { id = createdVisitor.Id }, createdVisitor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(int id, VisitorAccessDetailsDTO dto)
        {
            await _visitorService.UpdateVisitorAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            await _visitorService.DeleteVisitorAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllVisitorsBysearchParams(VisitorAccessDetailsDTO Params)
        {

            return Ok(await _visitorService.GetAllVisitorsBysearchParams(Params));
        }
    }
}
