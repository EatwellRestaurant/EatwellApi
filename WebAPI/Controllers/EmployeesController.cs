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
        public async Task<IActionResult> AddForManagerAsync([FromForm] EmployeeUpsertDto employeeUpsertDto)
            => Ok(await _employeeService.AddForManagerAsync(employeeUpsertDto));
        
        
        
        [HttpPost] 
        public async Task<IActionResult> AddForAdminAsync([FromForm] EmployeeUpsertDtoForAdmin employeeUpsertDto)
            => Ok(await _employeeService.AddForAdminAsync(employeeUpsertDto));



        [HttpGet] 
        public async Task<IActionResult> GetAllForManagerAsync([FromQuery] PaginationRequest paginationRequest)
            => Ok(await _employeeService.GetAllForManagerAsync(paginationRequest));
        
        
        
        [HttpGet]
        public async Task<IActionResult> GetAllForAdminAsync([FromQuery] PaginationRequest paginationRequest)
            => Ok(await _employeeService.GetAllForAdminAsync(paginationRequest));
        
        

        [HttpGet] 
        public async Task<IActionResult> GetFilteredEmployeesForAdminAsync([FromQuery] PaginationRequest paginationRequest, [FromQuery] EmployeeAdminFilterDto employeeAdminFilterDto)
            => Ok(await _employeeService.GetFilteredEmployeesForAdminAsync(paginationRequest, employeeAdminFilterDto));
        
        
        
        [HttpGet]  
        public async Task<IActionResult> GetFilteredEmployeesForManagerAsync([FromQuery] PaginationRequest paginationRequest, [FromQuery] EmployeeFilterRequestDto employeeFilterRequestDto)
            => Ok(await _employeeService.GetFilteredEmployeesForManagerAsync(paginationRequest, employeeFilterRequestDto));



        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetForAdmin(int employeeId)
            => Ok(await _employeeService.GetForAdminAsync(employeeId));
        
        
        
        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetForManager(int employeeId)
            => Ok(await _employeeService.GetForManagerAsync(employeeId));
    }
}
