namespace EatwellApi.Application.Dtos.Reservation
{
    public class ReservationDetailDto : ReservationListDto
    {
        public string Email { get; set; }

        public string? Note { get; set; }

    }
}
