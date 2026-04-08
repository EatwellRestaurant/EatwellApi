using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Behaviors.Authorization;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.User.GetOverview
{
    [Secured(OperationClaimEnum.Admin)]
    public class GetUsersOverviewQueryRequest : PaginationRequest, IRequest<DataResponse<UsersOverviewDto>>, ICacheableQuery
    {
        string ICacheableQuery.CacheKey => $"users:overview:page:{PageNumber}:size:{PageSize}";
    }
}
