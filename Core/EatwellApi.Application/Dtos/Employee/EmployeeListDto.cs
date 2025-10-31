using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Employee
{
    public class EmployeeListDto : IDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PositionName { get; set; }

        public string PositionDisplayName { get; set; }

        public string BranchName { get; set; }

        public DateTime HireDate { get; set; }

        public decimal? Salary { get; set; }

        public string WorkStatusName { get; set; }

        public string WorkStatusDisplayName { get; set; }

    }
}
