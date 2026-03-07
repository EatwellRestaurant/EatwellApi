using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Behaviors.Authorization;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.Reservation.GetOverview
{
    [Secured(OperationClaimEnum.Admin)]
    public class GetReservationOverviewQueryRequest : PaginationRequest, IRequest<DataResponse<ReservationsOverviewDto>>, ICacheableQuery
    {
        public int BranchId { get; set; }


        public string GetCacheKey()
            => $"{GetType().Name}:Branch_{BranchId}:Page_{PageNumber}_{PageSize}";
    }
}
