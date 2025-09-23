using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearsController : ControllerBase
    {
        readonly IYearService _yearService;

        public YearsController(IYearService yearService)
        {
            _yearService = yearService;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _yearService.GetAllAsync());
    }
}
