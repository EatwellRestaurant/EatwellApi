using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Behaviors.Authorization;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.Employee.GetFilterOptions
{
    [Secured(OperationClaimEnum.Admin)]
    public class GetEmployeeFilterOptionsQueryRequest : IRequest<DataResponse<EmployeeFilterOptionsDto>>, ICacheableQuery
    {
    }
}
