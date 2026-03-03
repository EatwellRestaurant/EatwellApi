using EatwellApi.Application.Dtos.Employee;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Features.Queries.Employee.GetOverview
{
    public class EmployeesOverviewDto : IDto
    {
        public int TotalEmployees { get; set; }

        public int ActiveEmployees { get; set; }

        public int Chefs { get; set; }

        public int Waiters { get; set; }

        public PaginationResponse<EmployeeListDto> Employees { get; set; }

    }
}
 