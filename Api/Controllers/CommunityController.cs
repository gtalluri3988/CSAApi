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
    public class CommunityController : AuthorizedCSABaseAPIController
    {
        public class Community
        {
            public List<CommunityDTO> CommunityResult {get; set;}
        }


        private readonly ICurrentUserService _currentUserService;
        public readonly ICommunityService _communityService;

        public CommunityController(
            ICurrentUserService currentUserService,
            ICommunityService communityService ,IUserService userService,
            ILogger<ResidentController> logger)
            : base(userService, logger)
        {
           
            _currentUserService = currentUserService;
            _communityService= communityService;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetCommunityTypes()
        {
            var Community = await _communityService.GetCommunityTypeList();
            return Ok(Community);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCommunity([FromBody] CommunityObject community)
        {
            var Community = await _communityService.GetCommunityTypeList();
            return Ok(Community);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommunities()
        {
            var Community = await _communityService.GetAllCommunitiesAsync();
            return Ok(new CommunityDTO { CommunityResult = Community });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommunityById(int id)
        {
            var Community = await _communityService.GetCommunityByIdAsync(id);
            if (Community == null)
                return NotFound();
            return Ok(Community);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommunity(CommunityDTO dto)
        {
            Random random = new Random();
            int randomNumber = random.Next(1000, 9999); // Generates a number between 1000 and 9999
            dto.CommunityId  = randomNumber.ToString();
            var createdCommunity = await _communityService.CreateCommunityAsync(dto);
            return CreatedAtAction(nameof(GetCommunityById), new { id = createdCommunity.Id }, createdCommunity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommunity(int id, CommunityDTO dto)
        {
            await _communityService.UpdateCommunityAsync(id, dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunity(int id)
        {
            await _communityService.DeleteCommunityAsync(id);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCommunitiesWithStates()
        {
            var Community = await _communityService.GetAllCommunitiesWithStatesAsync();
            return Ok(new CommunityDTO { CommunityResult = Community });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCommunitiesWithResidentCount()
        {
            var CommunityResidentCount = await _communityService.GetCommunitiesWithResidentCountAsync();
            return Ok(CommunityResidentCount);
        }

    }
}
