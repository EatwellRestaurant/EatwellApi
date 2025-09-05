using Business.Abstract;
using Entities.Dtos.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
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

    }
}
