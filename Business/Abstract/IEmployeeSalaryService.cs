using Core.Requests;
using Core.ResponseModels;
using Entities.Dtos.EmployeeSalary;
using Entities.Dtos.Year;

namespace Business.Abstract
{
    public interface IEmployeeSalaryService
    {
        Task<PaginationResponse<EmployeeFinancialListDto>> GetEmployeeSalaryAsync(int employeeId, EmployeeSalaryFilterRequestDto employeeSalaryFilterRequestDto, PaginationRequest paginationRequest);

        Task<DataResponse<EmployeeSalaryFilterOptionsDto>> GetFilterOptionsAsync(int employeeId);
    }
}
