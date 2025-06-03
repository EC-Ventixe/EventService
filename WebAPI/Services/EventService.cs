using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dtos;
using WebAPI.Entites;

namespace WebAPI.Services;

public class EventService(DataContext context, HttpClient httpClient)
{
    private readonly DataContext _context = context;
    private readonly HttpClient _httpClient = httpClient;


    // ----- CREATE -----
    public async Task<EventEntity> AddEventAsync(EventEntity eventEntity, TicketDto ticketDto)
    {
        var http = await _httpClient.PostAsJsonAsync("https://ventixeticketserviceapp.azurewebsites.net/api/ticket/createticket", ticketDto);

        await _context.Events.AddAsync(eventEntity);
        await _context.SaveChangesAsync();

        return eventEntity;
    }



    // ----- READ -----
    public async Task<List<EventEntity>> GetAllEventsAsync()
    {
        return await _context.Events.ToListAsync();
    }
    public async Task<EventEntity?> GetEventByIdAsync(string id)
    {
        return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<EventWithPriceDto>> GetAllEventsWithPricesAsync()
    {
        var events = await _context.Events.ToListAsync();
        var response = await _httpClient.GetAsync($"https://ventixeticketserviceapp.azurewebsites.net/api/ticket/getticket");
         
        var ticketDtos = await response.Content.ReadFromJsonAsync<List<TicketDto>>();

        var result = events.Select(e => new EventWithPriceDto
        {
            Event = e,
            Ticket = ticketDtos?.FirstOrDefault(t => t.EventId == e.Id) ?? new TicketDto()
        }).ToList();

        return result;
    }




    // ----- UPDATE -----
    public async Task UpdateEventAsync(EventEntity eventEntity)
    {
        _context.Events.Update(eventEntity);
        await _context.SaveChangesAsync();
    }



    // ----- DELETE -----
    public async Task DeleteEventAsync(string id)
    {
        var eventEntity = await GetEventByIdAsync(id);
        if (eventEntity != null)
        {
            _context.Events.Remove(eventEntity);
            await _context.SaveChangesAsync();
        }
    }
}
