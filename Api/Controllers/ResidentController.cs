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
    public class ResidentController : AuthorizedCSABaseAPIController
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly ICommunityService _communityService;
        public readonly IResidentService _residentService;
        public ResidentController(
            ICurrentUserService currentUserService, 
            ICommunityService communityService,
            IResidentService residentService,
            IUserService userService,
            ILogger<ResidentController> logger)
            : base(userService, logger)
        {
            _currentUserService = currentUserService;
            _communityService = communityService;
            _residentService = residentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllResidentsByCommunity(int communityId)
        {
            var Residents = await _residentService.GetAllResidentsByCommunityAsync(communityId);
            return Ok(Residents);
        }
        [HttpGet]
        public async Task<IActionResult> GetResidentsByResidentId(int residentId)
        {
            //if (CurrentUser != null)
            //{
            //}
            var Residents = await _residentService.GetResidentsByResidentIdAsync(residentId);
            return Ok(Residents);
        }
        //[HttpPost]
        //public async Task<IActionResult> SaveResident([FromBody] CommunityObject community)
        //{
        //    var Community = await _communityService.GetCommunityTypeList();
        //    return Ok(Community);
        //}
        [HttpPost]
        public async Task<IActionResult> CreateResident(ResidentDTO residentModel)
        {
            Random random = new Random();           
            var createdResident = await _residentService.CreateResidentAsync(residentModel);
            return CreatedAtAction(nameof(GetResidentsByResidentId), new { id = createdResident.Id }, createdResident);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResident(int id, ResidentDTO dto)
        {
            await _residentService.UpdateResidentAsync(id, dto);
            return NoContent();
        }
    }
}
