using EatwellApi.Application.Wrappers;

namespace EatwellApi.Application.Dtos.Employee
{
    public class EmployeeStatisticsDto
    {
        public int EmployeeCount { get; set; }

        public int ActiveEmployeeCount { get; set; }

        public int ChefCount { get; set; }

        public int WaiterCount { get; set; }

        public PaginationResponse<EmployeeListDto> EmployeeListDtos { get; set; }
    }
}