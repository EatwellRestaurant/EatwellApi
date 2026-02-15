using EatwellApi.Application.Abstractions.Repositories.Reservation;
using EatwellApi.Persistence.Context;
using DomainReservation = EatwellApi.Domain.Entities.Reservation;

namespace EatwellApi.Persistence.Repositories.Reservation
{
    public class ReservationReadRepository : ReadRepository<DomainReservation>, IReservationReadRepository
    {
        public ReservationReadRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
