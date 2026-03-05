using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Behaviors.Authorization;
using EatwellApi.Application.Behaviors.Cache;
using EatwellApi.Application.Dtos.Dashboard;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.Dashboard.Get
{
    [Secured(OperationClaimEnum.Admin)]
    [Cache(60)]
    public class GetStatisticsQueryRequest : IRequest<DataResponse<DashboardStatisticsDto>>, ICacheableQuery
    {
    }
}
