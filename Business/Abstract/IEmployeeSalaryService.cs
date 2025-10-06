using Core.Requests;
using Core.ResponseModels;
using Entities.Dtos.EmployeeSalary;
using Entities.Dtos.Year;

namespace Business.Abstract
{
    public interface IEmployeeSalaryService
    {
        Task<PaginationResponse<EmployeeFinancialListDto>> GetEmployeeSalaryFilteredAsync(int employeeId, EmployeeSalaryFilterRequestDto employeeSalaryFilterRequestDto, PaginationRequest paginationRequest);

        Task<List<YearListDto>> GetEmployeeSalaryYearsAsync(int employeeId);
    }
}
