using DomainReservation = EatwellApi.Domain.Entities.Reservation;

namespace EatwellApi.Application.Abstractions.Repositories.Reservation
{
    public interface IReservationReadRepository : IReadRepository<DomainReservation>
    {
    }
}
