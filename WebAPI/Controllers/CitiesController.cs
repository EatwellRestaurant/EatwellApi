using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(City city)
        {
            var result = await _cityService.Add(city);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(City city)
        {
            var result = _cityService.Delete(city);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(City city)
        {
            var result = _cityService.Update(city);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _cityService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _cityService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
