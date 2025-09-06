using Business.Abstract;
using Core.Requests;
using Entities.Dtos.Employee;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }



        [HttpPost]
        public async Task<IActionResult> Add(EmployeeUpsertDto employeeUpsertDto)
            => Ok(await _employeeService.Add(employeeUpsertDto));



        [HttpGet] 
        public async Task<IActionResult> GetAllForManagerAsync([FromQuery] PaginationRequest paginationRequest)
            => Ok(await _employeeService.GetAllForManagerAsync(paginationRequest));
        
        
        
        [HttpGet]
        public async Task<IActionResult> GetAllForAdminAsync([FromQuery] PaginationRequest paginationRequest)
            => Ok(await _employeeService.GetAllForAdminAsync(paginationRequest));

    }
}
