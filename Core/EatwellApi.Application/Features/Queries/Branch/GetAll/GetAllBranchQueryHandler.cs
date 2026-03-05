using EatwellApi.Application.Abstractions.Services.Branch;
using EatwellApi.Application.Dtos.Branch;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.Branch.GetAll
{
    public class GetAllBranchQueryHandler(IBranchService branchService) : IRequestHandler<GetAllBranchQueryRequest, PaginationResponse<BranchListWithCityDto>>
    {
        readonly IBranchService _branchService = branchService;



        public Task<PaginationResponse<BranchListWithCityDto>> Handle(GetAllBranchQueryRequest request, CancellationToken cancellationToken)
            => _branchService.GetAllAsync(request);
    }
}
