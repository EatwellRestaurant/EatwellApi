using Business.Abstract;
using Core.Requests;
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
        public async Task<IActionResult> GetEmployeeTaskFilteredAsync
            (int employeeId, [FromQuery] EmployeeTaskFilterRequestDto employeeTaskFilterRequestDto, [FromQuery] PaginationRequest paginationRequest)
            => Ok(await _employeeTaskService.GetEmployeeTaskFilteredAsync(employeeId, employeeTaskFilterRequestDto, paginationRequest));




        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatisticsAsync(int employeeId)
            => Ok(await _employeeTaskService.GetStatisticsAsync(employeeId));

    }
}
