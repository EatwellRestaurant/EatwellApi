using Business.Abstract;
using Core.Requests;
using Core.ResponseModels;
using Entities.Dtos.EmployeeTask;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/employees/{employeeId}/tasks")]
    [ApiController]
    public class EmployeeTasksController : ControllerBase
    {
        readonly IEmployeeTaskService _employeeTaskService;

        public EmployeeTasksController(IEmployeeTaskService employeeTaskService)
        {
            _employeeTaskService = employeeTaskService;
        }




        [HttpGet]
        public async Task<IActionResult> GetEmployeeTasksAsync
            (int employeeId, [FromQuery] EmployeeTaskFilterRequestDto employeeTaskFilterRequestDto, [FromQuery] PaginationRequest paginationRequest)
            => Ok(await _employeeTaskService.GetEmployeeTasksAsync(employeeId, employeeTaskFilterRequestDto, paginationRequest));




        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatisticsAsync(int employeeId)
            => Ok(await _employeeTaskService.GetStatisticsAsync(employeeId));




        [HttpGet("filters")]
        public IActionResult GetFilterOptions()
            => Ok(_employeeTaskService.GetFilterOptions());




        [HttpGet("overview")]
        public async Task<IActionResult> GetEmployeeTaskOverview
            (int employeeId, [FromQuery] EmployeeTaskFilterRequestDto employeeTaskFilterRequestDto, [FromQuery] PaginationRequest paginationRequest)
            => Ok(
                new DataResponse<EmployeeTaskOverviewDto>(
                    new()
                    { 
                        Statistics = await _employeeTaskService.GetStatisticsAsync(employeeId),
                        FilterOptions = _employeeTaskService.GetFilterOptions(),
                        Tasks = await _employeeTaskService.GetEmployeeTasksAsync(employeeId, employeeTaskFilterRequestDto, paginationRequest)
                    }));
        


    }
}
