using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entites;

namespace WebAPI.Services;

public class EventService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<List<EventEntity>> GetAllEventsAsync()
    {
        return await _context.Events.ToListAsync();
    }
    public async Task<EventEntity?> GetEventByIdAsync(string id)
    {
        return await _context.Events.FindAsync(id);
    }
    public async Task AddEventAsync(EventEntity eventEntity)
    {
        await _context.Events.AddAsync(eventEntity);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateEventAsync(EventEntity eventEntity)
    {
        _context.Events.Update(eventEntity);
        await _context.SaveChangesAsync();
    }
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
