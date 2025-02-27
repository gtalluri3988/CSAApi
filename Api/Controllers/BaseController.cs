using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Models;
using YourNamespace.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/common/[action]")]
    public class BaseController : ControllerBase
    {
        public class Community
        {
            public List<CommunityObject> CommunityResult { get; set; }
        }


        private readonly ICurrentUserService _currentUserService;
        public readonly ICommunityService _communityService;

        public BaseController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            
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


    }
}
