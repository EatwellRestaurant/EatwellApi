using Business.Abstract;
using Core.Requests;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationRequest? paginationRequest)
        {
            if (paginationRequest!.PageNumber == 0 || paginationRequest.PageSize == 0)
                paginationRequest = null;

            return Ok(await _cityService.GetAll(paginationRequest));
        }
    }
}
