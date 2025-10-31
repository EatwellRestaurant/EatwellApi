namespace EatwellApi.Application.Filters.Reservation
{
    public class ReservationFilter
    {
        public string? FullName { get; set; }

        public int? TableId { get; set; }

        public DateRangeFilter DateRangeFilter { get; set; }
    }
}
