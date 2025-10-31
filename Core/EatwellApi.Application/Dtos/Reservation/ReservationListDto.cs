using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Reservation
{
    public class ReservationListDto : IDto
    {
        public int Id { get; set; }

        public int TableNo { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public DateTime ReservationDate { get; set; }

        public byte PersonCount { get; set; }
    }
}
