namespace WebAPI.Dtos
{
    public class TicketDto
    {
        public string EventId { get; set; } = null!;
        public int TicketAmount { get; set; }
        public int Ticketsleft { get; set; }
        public decimal TicketPrice { get; set; }
    }
}
