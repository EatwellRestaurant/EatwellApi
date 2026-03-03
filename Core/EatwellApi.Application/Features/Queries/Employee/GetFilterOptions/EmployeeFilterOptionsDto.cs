using EatwellApi.Application.Dtos.Branch;
using EatwellApi.Application.Dtos.Employee;
using EatwellApi.Application.Dtos.OperationClaim;
using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Features.Queries.Employee.GetFilterOptions
{
    public class EmployeeFilterOptionsDto : IDto
    {
        public List<WorkStatusDto> WorkStatusDtos { get; set; }

        public List<OperationClaimListDto> OperationClaimListDtos { get; set; }

        public List<BaseBranchDto> BranchDtos { get; set; }

    }
}
