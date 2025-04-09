using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Country country)
        {
            var result = await _countryService.Add(country);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(Country country)
        {
            var result = _countryService.Delete(country);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Country country)
        {
            var result = _countryService.Update(country);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _countryService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _countryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
