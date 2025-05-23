using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Models;
using YourNamespace.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using BusinessLogic.Services;
using DB.Entity;
using BusinessLogic.Models.Users;

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
            try
            {
                return Ok(await _residentService.GetAllResidentsByCommunityAsync(communityId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetResidentsByResidentId(int residentId)
        {
            var Residents = await _residentService.GetResidentsByResidentIdAsync(residentId);
            return Ok(await _residentService.GetResidentsByResidentIdAsync(residentId));
        }
      
        [HttpPost]
        public async Task<IActionResult> CreateResident(ResidentDTO residentModel)
        {
            try
            {
                Random random = new Random();
                var createdResident = await _residentService.CreateResidentAsync(residentModel);
                return CreatedAtAction(nameof(GetResidentsByResidentId), new { id = createdResident.Id }, createdResident);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateResident(int id, ResidentDTO dto)
        {
            await _residentService.UpdateResidentAsync(id, dto);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetResidentByNric(string nric,int communityId)
        {
            return Ok(await _residentService.GetResidentsByNRICAsync(nric, communityId));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllResidentsByCommunityDropdown(int communityId)
        {

            return Ok(await _residentService.GetAllResidentsByCommunityDropdownAsync(communityId, ""));
        }


        [HttpGet]
        public async Task<IActionResult> GetResidentsNameandContactByAddresses(string roadNo, string blockNo, string level, string houseNo)
        {
            return Ok(await _residentService.GetResidentsNameandContactByAddresses(roadNo, blockNo, level, houseNo));
        }

        [HttpPost]
        public async Task<IActionResult> GetAllResidentsBysearchParams(ResidentDTO Params)
        {

            return Ok(await _residentService.SearchResidentsByCommunityIdAsync(Params));
        }

        //[HttpPost]
        //public async Task<IActionResult> GetResidentHierarchy(int communityId, string roadNo = null, string blockNo = null, string level = null, string targetField = "RoadNo")
        //{
        //    var result = await _residentService.GetResidentHierarchyAsync(communityId, roadNo, blockNo, level, targetField);
        //    return Ok(result);
        //}

        [HttpPost]
        public async Task<IActionResult> GetResidentHierarchy([FromBody] ResidencyHierarchyModel request)
        {
            var result = await _residentService.GetResidentHierarchyAsync(
                request.CommunityId,
                request.RoadNo,
                request.BlockNo,
                request.Level,
                request.TargetField
            );
            return Ok(result);
        }

    }
}
