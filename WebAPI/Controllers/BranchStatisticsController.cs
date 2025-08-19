using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchStatisticsController : ControllerBase
    {
        readonly IBranchStatisticsService _branchStatisticsService;

        public BranchStatisticsController(IBranchStatisticsService branchStatisticsService)
        {
            _branchStatisticsService = branchStatisticsService;
        }



        [HttpGet]
        public async Task<IActionResult> GetStatistics(int? branchId)
            => Ok(await _branchStatisticsService.GetStatistics(branchId));
    }
}
