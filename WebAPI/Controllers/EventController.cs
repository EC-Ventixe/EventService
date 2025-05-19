using Microsoft.AspNetCore.Mvc;
using WebAPI.Entites;
using WebAPI.Services;

namespace WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class EventController(EventService eventService) : Controller
{
    private readonly EventService _eventService = eventService;



    [HttpGet("getevents")]
    public async Task<IActionResult> GetAllEvents()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpPost("addevent")]
    public async Task<IActionResult> AddEvent([FromBody] EventEntity eventEntity)
    {
        if (eventEntity == null)
        {
            return BadRequest("Event cannot be null");
        }
        await _eventService.AddEventAsync(eventEntity);
        return CreatedAtAction(nameof(GetAllEvents), new { id = eventEntity.Id }, eventEntity);
    }

}
