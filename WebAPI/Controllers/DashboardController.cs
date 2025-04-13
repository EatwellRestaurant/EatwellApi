using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardsController : ControllerBase
    {
        readonly IDashboardService _dashboardService;

        public DashboardsController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }



        [HttpGet]
        public async Task<IActionResult> GetStatistics() 
            => Ok(await _dashboardService.GetStatistics());
        
    }
}
