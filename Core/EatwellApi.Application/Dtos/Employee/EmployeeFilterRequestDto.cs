using EatwellApi.Domain.Enums.Employee;

namespace EatwellApi.Application.Dtos.Employee
{
    public class EmployeeFilterRequestDto
    {
        public string? FullName { get; set; }

        public WorkStatusType? WorkStatus { get; set; }

        public int? OperationClaimId { get; set; }
    }
}
