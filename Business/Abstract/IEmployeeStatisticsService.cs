using Core.Requests;
using Core.ResponseModels;
using Entities.Dtos.Employee;
using Entities.Dtos.EmployeeSalary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeStatisticsService
    {
        Task<DataResponse<EmployeeStatisticsDto>> GetStatistics(PaginationRequest paginationRequest);

        Task<EmployeeFilterOptionsDto> GetEmployeeFilterOptionsAsync();

        Task<EmployeeSalaryFilterOptionsDto> GetEmployeeSalaryFilterOptionsAsync(int employeeId);
    }
}
