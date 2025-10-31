using EatwellApi.Application.Wrappers;

namespace EatwellApi.Application.Dtos.EmployeeTask
{
    public class EmployeeTaskOverviewDto
    {
        public DataResponse<EmployeeTaskStatisticsDto> Statistics { get; set; }

        public DataResponse<EmployeeTaskFilterOptionsDto> FilterOptions { get; set; }

        public PaginationResponse<EmployeeTaskListDto> Tasks { get; set; }

    }
}
