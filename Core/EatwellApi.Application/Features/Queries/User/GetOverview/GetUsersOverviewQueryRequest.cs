using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Abstractions.Security;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.User.GetOverview
{
    public class GetUsersOverviewQueryRequest : PaginationRequest, IRequest<DataResponse<UsersOverviewDto>>, ISecuredRequest, ICacheableQuery
    {
        public string[] Roles => [OperationClaimEnum.Admin.ToString()];
    }
}
