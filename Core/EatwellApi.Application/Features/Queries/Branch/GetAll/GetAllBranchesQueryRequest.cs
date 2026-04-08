using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Dtos.Branch;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.Branch.GetAll
{
    public class GetAllBranchesQueryRequest : PaginationRequest, IRequest<PaginationResponse<BranchListWithCityDto>>, ICacheableQuery
    {
        string ICacheableQuery.CacheKey => $"branches:page:{PageNumber}:size:{PageSize}";
    }
}
