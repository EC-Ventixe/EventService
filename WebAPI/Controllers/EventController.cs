using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
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
        var events = await _eventService.GetAllEventsWithPricesAsync();
        return Ok(events);
    }

    [HttpPost("addevent")]
    public async Task<IActionResult> AddEvent([FromBody] EventDto eventDto)
    {
        if (eventDto == null)
        {
            return BadRequest("Event cannot be null");
        }
        var evententity = new EventEntity
        {
            EventName = eventDto.EventName,
            EventDescription = eventDto.EventDescription,
            EventImgUrl = eventDto.EventImgUrl,
            Location = eventDto.Location,
            City = eventDto.City,
            StartDate = eventDto.StartDate,
            EndDate = eventDto.EndDate,
            TicketStartDate = eventDto.TicketStartDate,
        };

        var ticket = new TicketDto
        {
            EventId = evententity.Id,
            TicketAmount = eventDto.TicketAmount,
            TicketPrice = eventDto.TicketPrice
        };

        var createdevent = await _eventService.AddEventAsync(evententity, ticket);
        return Ok(createdevent);
    }

    [HttpGet("getevent/{id}")]
    public async Task<IActionResult> GetEventById(string id)
    {
        var eventEntity = await _eventService.GetEventByIdAsync(id);
        if (eventEntity == null)
        {
            return NotFound();
        }
        return Ok(eventEntity);
    }

}
