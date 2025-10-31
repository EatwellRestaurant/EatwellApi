using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Reservation
{
    public class ReservationUpsertDto : IDto
    {
        public int BranchId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime ReservationDate { get; set; }

        public int PersonCount { get; set; }

        public string? Note { get; set; }
    }
}
