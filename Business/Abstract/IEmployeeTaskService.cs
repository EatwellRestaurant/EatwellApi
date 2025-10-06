using Core.Requests;
using Core.ResponseModels;
using Entities.Dtos.EmployeeTask;

namespace Business.Abstract
{
    public interface IEmployeeTaskService
    {
        Task<PaginationResponse<EmployeeTaskListDto>> GetEmployeeTaskFilteredAsync(int employeeId, EmployeeTaskFilterRequestDto employeeTaskFilterRequest, PaginationRequest paginationRequest);

        Task<EmployeeTaskStatisticsDto> GetStatisticsAsync(int employeeId);
    }
} 
 