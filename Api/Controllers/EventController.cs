using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DB.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EventController : AuthorizedCSABaseAPIController
    {
        private readonly IEventService _eventService;
        private readonly ICurrentUserService _currentUserService;

        public EventController(IEventService eventService,
            ICurrentUserService currentUserService,
            IUserService userService,
            ILogger<EventController> logger)
            : base(userService, logger)
        {
            _currentUserService = currentUserService;
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            return Ok(await _eventService.GetAllEventsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetEventById(int id)
        {
            var Event = await _eventService.GetEventByIdAsync(id);
            if (Event == null)
                return NotFound();
            return Ok(Event);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventDTO dto)
        {
            var Event = await _eventService.SaveEventAsync(dto);
            return CreatedAtAction(nameof(GetEventById), new { id = Event.Id }, Event);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent(int id, EventDTO dto)
        {
            await _eventService.UpdateEventAsync(id, dto);
            return NoContent();
        }

    }
}
