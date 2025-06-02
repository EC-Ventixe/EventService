using WebAPI.Entites;

namespace WebAPI.Dtos
{
    public class EventWithPriceDto
    {
        public EventEntity Event { get; set; } = null!;

        public TicketDto Ticket { get; set; } = null!;
    }
}
