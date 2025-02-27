using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;

[Authorize]
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ICurrentUserService _currentUserService;

    public UserController(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    [HttpGet("current")]
    public IActionResult GetCurrentUser()
    {
        return Ok(new
        {
            UserId = _currentUserService.GetUserId(),
            Username = _currentUserService.GetUsername(),
            Email = _currentUserService.GetEmail()
        });
    }
}
