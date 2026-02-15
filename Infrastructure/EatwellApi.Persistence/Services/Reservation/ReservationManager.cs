using EatwellApi.Application.Abstractions.Repositories.Reservation;
using EatwellApi.Application.Abstractions.Services.Reservation;

namespace EatwellApi.Persistence.Services.Reservation
{
    public class ReservationManager : IReservationService
    {
        readonly IReservationReadRepository _readRepository;

        public ReservationManager(IReservationReadRepository readRepository)
        {
            _readRepository = readRepository;
        }



        public Task<int> CountReservationsAsync(int? branchId = null)
            => _readRepository.CountAsync(r => !r.IsDeleted && (!branchId.HasValue || r.BranchId == branchId));
    }
}
