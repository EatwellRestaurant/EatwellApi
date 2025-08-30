using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadOfficeController : ControllerBase
    {
        readonly IHeadOfficeService _headOfficeService;


        public HeadOfficeController(IHeadOfficeService headOfficeService)
        {
            _headOfficeService = headOfficeService;
        }




        [HttpGet]
        public async Task<IActionResult> GetAsync()
            => Ok(await _headOfficeService.GetAsync());
    }
}
