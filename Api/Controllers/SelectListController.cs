using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SelectListController : ControllerBase
    {
        private readonly IDropDownService _dropDownService;
        public SelectListController(IDropDownService dropdownService)
        {
            _dropDownService = dropdownService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSelectListAsync(string inputType)
        {
            return Ok(await _dropDownService.GetSelectList(inputType));
        }



        
    }
}
