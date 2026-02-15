using EatwellApi.Application.Abstractions.Security;
using EatwellApi.Application.Dtos.Dashboard;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.Dashboard.Get
{
    public class GetStatisticsQueryRequest : IRequest<DataResponse<DashboardStatisticsDto>>, ISecuredRequest
    {
        public string[] Roles => [OperationClaimEnum.Admin.ToString()];
    }
}
