namespace WebAPI.Dtos
{
    public class EventDto
    {
        public string EventName { get; set; } = null!;
        public string? EventDescription { get; set; }
        public string? EventImgUrl { get; set; }
        public string Location { get; set; } = null!;
        public string City { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime TicketStartDate { get; set; }
        public int TicketAmount { get; set; }
        public decimal TicketPrice { get; set; } 
    }
}
