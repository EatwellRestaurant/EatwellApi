using EatwellApi.Application.Filters.Reservation;
using EatwellApi.Domain.Entities;

namespace EatwellApi.Application.Extensions
{
    public static class ReservationQueryableExtensions
    {
        public static IQueryable<Reservation> FilterByFullName(this IQueryable<Reservation> query, string? fullName)
            => fullName != null ? query.Where(x => x.FullName.Contains(fullName)) : query;



        public static IQueryable<Reservation> FilterByTableId(this IQueryable<Reservation> query, int? tableId)
            => tableId != null ? query.Where(x => x.TableId == tableId) : query;



        public static IQueryable<Reservation> FilterByDate(this IQueryable<Reservation> query, DateRangeFilter dateRangeFilter)
            => query.Where(x => x.ReservationDate.Date >= dateRangeFilter.StartDate.Date
                && x.ReservationDate.Date <= dateRangeFilter.EndDate.Date);

    }
}
