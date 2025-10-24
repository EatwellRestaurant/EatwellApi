using Core.Requests;
using Core.ResponseModels;
using Entities.Dtos.EmployeeTask;

namespace Business.Abstract
{
    public interface IEmployeeTaskService
    {
        Task<PaginationResponse<EmployeeTaskListDto>> GetEmployeeTasksAsync(int employeeId, EmployeeTaskFilterRequestDto employeeTaskFilterRequest, PaginationRequest paginationRequest);

        Task<DataResponse<EmployeeTaskStatisticsDto>> GetStatisticsAsync(int employeeId);

        DataResponse<EmployeeTaskFilterOptionsDto> GetFilterOptions();
    }
} 
 