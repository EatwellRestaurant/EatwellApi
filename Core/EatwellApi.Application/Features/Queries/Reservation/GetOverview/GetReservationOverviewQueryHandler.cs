using EatwellApi.Application.Abstractions.Repositories.Branch;
using EatwellApi.Application.Constants.Messages;
using EatwellApi.Application.Dtos.Reservation;
using EatwellApi.Application.Dtos.Table;
using EatwellApi.Application.Extensions;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Exceptions.General;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DomainBranch = EatwellApi.Domain.Entities.Branch;

namespace EatwellApi.Application.Features.Queries.Reservation.GetOverview
{
    public class GetReservationOverviewQueryHandler(IBranchReadRepository readRepository) : IRequestHandler<GetReservationOverviewQueryRequest, DataResponse<ReservationsOverviewDto>>
    {
        readonly IBranchReadRepository _readRepository = readRepository;



        public async Task<DataResponse<ReservationsOverviewDto>> Handle(GetReservationOverviewQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<DomainBranch> query = _readRepository
                .Where(b => !b.IsDeleted && b.Id == request.BranchId)
                .AsNoTracking();


            DateTime now = DateTime.UtcNow;
            DateTime startOfWeek = now.Date.AddDays(-(int)now.DayOfWeek); // Pazar gününü alıyoruz
            DateTime today = now.Date;

            ReservationsOverviewStatistics statistics = await query
                .Select(b => new ReservationsOverviewStatistics(
                    b.Reservations.Count(),
                    b.Reservations.Count(r => r.ReservationDate >= startOfWeek && r.ReservationDate <= now),
                    b.Reservations.Count(r => r.ReservationDate == today),
                    b.Tables.Count()
                ))
                .SingleOrDefaultAsync(cancellationToken) 
                ?? throw new EntityNotFoundException("Şube");


            List<TableListDto> tables = await query
                .SelectMany(b => b.Tables)
                .Select(t => new TableListDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    No = t.No,
                    Capacity = t.Capacity
                })
                .ToListAsync(cancellationToken);


            List<ReservationListDto> reservations = await query
                .SelectMany(b => b.Reservations)
                .ApplyPagination(request)
                .Select(r => new ReservationListDto
                {
                    Id = r.Id,
                    TableNo = r.Table.No,
                    FullName = r.FullName,
                    Phone = r.Phone,
                    PersonCount = r.PersonCount,
                    ReservationDate = r.ReservationDate
                })
                .ToListAsync(cancellationToken);


            return new(new()
            {
                TotalReservations = statistics.TotalReservations,
                ThisWeekReservations = statistics.ThisWeekReservations,
                TodayReservations = statistics.TodayReservations,
                TotalTables = statistics.TotalTables,
                Tables = tables,
                Reservations = new(reservations, request, statistics.TotalReservations)
            },
            CommonMessages.StatisticsFetched);
        }
    }
}
