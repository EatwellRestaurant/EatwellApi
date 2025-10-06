using Business.Abstract;
using Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeStatisticsController : ControllerBase
    {
        readonly IEmployeeStatisticsService _employeeStatisticsService;

        public EmployeeStatisticsController(IEmployeeStatisticsService employeeStatisticsService)
        {
            _employeeStatisticsService = employeeStatisticsService;
        }



        [HttpGet]
        public async Task<IActionResult> GetStatistics([FromQuery] PaginationRequest paginationRequest)
            => Ok(await _employeeStatisticsService.GetStatistics(paginationRequest));
        
        
        
        [HttpGet]
        public async Task<IActionResult> GetEmployeeFilterOptionsAsync()
            => Ok(await _employeeStatisticsService.GetEmployeeFilterOptionsAsync());
        
        
        
        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeSalaryFilterOptionsAsync(int employeeId)
            => Ok(await _employeeStatisticsService.GetEmployeeSalaryFilterOptionsAsync(employeeId));
        
        
        
        [HttpGet]
        public IActionResult GetEmployeeTaskFilterOptionsAsync()
            => Ok(_employeeStatisticsService.GetEmployeeTaskFilterOptionsAsync());



    }
}
