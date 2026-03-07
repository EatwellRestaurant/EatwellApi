using EatwellApi.Application.Dtos.Reservation;

namespace EatwellApi.Application.Features.Queries.Reservation.GetOverview
{
    public sealed record ReservationsOverviewStatistics(
        int TotalReservations,
        int ThisWeekReservations,
        int TodayReservations,
        int TotalTables
    );
}
