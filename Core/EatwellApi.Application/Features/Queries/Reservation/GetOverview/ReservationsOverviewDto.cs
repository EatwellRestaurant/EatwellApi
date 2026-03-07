using EatwellApi.Application.Dtos.Reservation;
using EatwellApi.Application.Dtos.Table;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Features.Queries.Reservation.GetOverview
{
    public class ReservationsOverviewDto : IDto
    {
        public int TotalReservations { get; set; }

        public int ThisWeekReservations { get; set; }
        
        public int TodayReservations { get; set; }
        
        public int TotalTables { get; set; }

        public List<TableListDto> Tables { get; set; }

        public PaginationResponse<ReservationListDto> Reservations { get; set; }
    }
}
