namespace EatwellApi.Application.Dtos.Employee
{
    public class EmployeeAdminFilterDto : EmployeeFilterRequestDto
    {
        public int? BranchId { get; set; }

    }
}
