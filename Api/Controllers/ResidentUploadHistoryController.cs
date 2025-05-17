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
    public class ResidentUploadHistoryController : AuthorizedCSABaseAPIController
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly ICommunityService _communityService;
        public readonly IResidentService _residentService;
        public readonly IResidentUploadHistoryService _residentUploadHistoryService;
        public ResidentUploadHistoryController(
            ICurrentUserService currentUserService,
            ICommunityService communityService,
            IResidentService residentService,
            IUserService userService,
            IResidentUploadHistoryService residentUploadHistoryService,
            ILogger<ResidentController> logger)
            : base(userService, logger)
        {
            _currentUserService = currentUserService;
            _communityService = communityService;
            _residentService = residentService;
            _residentUploadHistoryService = residentUploadHistoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllResidentsUploadHistory()
        {

            return Ok(await _residentUploadHistoryService.GetAllResidentUploadHistoryAsync());
        }
        // [HttpGet]
        //public async Task<IActionResult> GetResidentAccessHistoryByResidentId(int residentId)
        //{
        //    var Residents = await _residentAccessHistoryService.GetResidentsByResidentIdAsync(residentId);
        //    return Ok(await _residentAccessHistoryService.GetResidentsByResidentIdAsync(residentId));
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateResidentAccessHistory(ResidentDTO residentModel)
        //{
        //    Random random = new Random();
        //    var createdResident = await _residentAccessHistoryService.CreateResidentAsync(residentModel);
        //    return CreatedAtAction(nameof(GetResidentAccessHistoryByResidentId), new { id = createdResident.Id }, createdResident);
        //}
        //[HttpPost]
        //public async Task<IActionResult> UpdateResidentAccessHistory(int id, ResidentDTO dto)
        //{
        //    await _residentAccessHistoryService.UpdateResidentAsync(id, dto);
        //    return NoContent();
        //}

    }


}
