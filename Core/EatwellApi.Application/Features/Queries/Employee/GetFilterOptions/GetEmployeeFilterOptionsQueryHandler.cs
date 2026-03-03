using EatwellApi.Application.Abstractions.Services.Branch;
using EatwellApi.Application.Abstractions.Services.OperationClaim;
using EatwellApi.Application.Constants.Messages;
using EatwellApi.Application.Dtos.Employee;
using EatwellApi.Application.Helpers;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.Employee;
using MediatR;

namespace EatwellApi.Application.Features.Queries.Employee.GetFilterOptions
{
    public class GetEmployeeFilterOptionsQueryHandler : IRequestHandler<GetEmployeeFilterOptionsQueryRequest, DataResponse<EmployeeFilterOptionsDto>>
    {
        readonly IOperationClaimService _operationClaimService;
        readonly IBranchService _branchService;

        public GetEmployeeFilterOptionsQueryHandler(IOperationClaimService operationClaimService, IBranchService branchService)
        {
            _operationClaimService = operationClaimService;
            _branchService = branchService;
        }


        public async Task<DataResponse<EmployeeFilterOptionsDto>> Handle(GetEmployeeFilterOptionsQueryRequest request, CancellationToken cancellationToken)
            => new(new()
            {
                WorkStatusDtos = EnumHelper.ToLookupList<WorkStatusType, WorkStatusDto>(),
                OperationClaimListDtos = await _operationClaimService.GetAllAsync(),
                BranchDtos = await _branchService.GetLookupAsync()
            },
                CommonMessages.FilterOptionsFetched);
    }
}
