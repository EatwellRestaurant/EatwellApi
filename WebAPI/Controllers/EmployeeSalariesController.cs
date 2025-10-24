using Business.Abstract;
using Core.Requests;
using Entities.Dtos.EmployeeSalary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/employees/{employeeId}/salaries")]
    [ApiController]
    public class EmployeeSalariesController : ControllerBase
    {
        readonly IEmployeeSalaryService _employeeSalaryService;

        public EmployeeSalariesController(IEmployeeSalaryService employeeSalaryService)
        {
            _employeeSalaryService = employeeSalaryService;
        }




        [HttpGet]
        public async Task<IActionResult> GetEmployeeSalaryAsync
            (int employeeId, [FromQuery] EmployeeSalaryFilterRequestDto employeeSalaryFilterRequestDto, [FromQuery] PaginationRequest paginationRequest)
            => Ok(await _employeeSalaryService.GetEmployeeSalaryAsync(employeeId, employeeSalaryFilterRequestDto, paginationRequest));




        [HttpGet("filters")]
        public async Task<IActionResult> GetFilterOptionsAsync(int employeeId)
            => Ok(await _employeeSalaryService.GetFilterOptionsAsync(employeeId));

    }
}
