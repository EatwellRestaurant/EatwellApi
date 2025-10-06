using Core.Requests;
using Core.ResponseModels;
using Entities.Dtos.Employee;
using Entities.Dtos.EmployeeSalary;
using Entities.Dtos.EmployeeTask;

namespace Business.Abstract
{
    public interface IEmployeeStatisticsService
    {
        Task<DataResponse<EmployeeStatisticsDto>> GetStatistics(PaginationRequest paginationRequest);

        Task<EmployeeFilterOptionsDto> GetEmployeeFilterOptionsAsync();

        Task<EmployeeSalaryFilterOptionsDto> GetEmployeeSalaryFilterOptionsAsync(int employeeId);

        EmployeeTaskFilterOptionsDto GetEmployeeTaskFilterOptionsAsync();
    }
}
