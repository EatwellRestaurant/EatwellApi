using Business.Abstract;
using Entities.Dtos.HeadOffice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadOfficesController : ControllerBase
    {
        readonly IHeadOfficeService _headOfficeService;


        public HeadOfficesController(IHeadOfficeService headOfficeService)
        {
            _headOfficeService = headOfficeService;
        }




        [HttpGet]
        public async Task<IActionResult> GetAsync()
            => Ok(await _headOfficeService.GetAsync());
        
        

        
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(HeadOfficeDto headOfficeDto)
            => Ok(await _headOfficeService.UpdateAsync(headOfficeDto));
    }
}
