using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Models;
using YourNamespace.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommunityController : ControllerBase
    {
        public class Community
        {
            public List<CommunityObject> CommunityResult {get; set;}
        }


        private readonly ICurrentUserService _currentUserService;
        public readonly ICommunityService _communityService;

        public CommunityController(ICurrentUserService currentUserService,ICommunityService communityService)
        {
            _currentUserService = currentUserService;
            _communityService= communityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommunityList()
        {
            var Community = await _communityService.GetCommunityList();
            return Ok(new Community { CommunityResult = Community });
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


    }
}
