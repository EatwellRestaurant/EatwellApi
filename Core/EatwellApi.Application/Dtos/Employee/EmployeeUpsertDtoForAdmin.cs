namespace EatwellApi.Application.Dtos.Employee
{
    public class EmployeeUpsertDtoForAdmin : EmployeeUpsertDto
    {
        public int BranchId { get; set; }
    }
}
