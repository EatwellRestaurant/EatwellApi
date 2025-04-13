using Business.Abstract;
using Entities.Dtos.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }



        [HttpGet]
        public async Task<IActionResult> Get(int countryId) 
            => Ok(await _countryService.Get(countryId));
        
        
        
        [HttpGet] 
        public async Task<IActionResult> GetForAdmin(int countryId) 
            => Ok(await _countryService.GetForAdmin(countryId));
            


        [HttpGet]
        public async Task<IActionResult> GetAll() 
            => Ok(await _countryService.GetAll());
        
        

        [HttpGet]
        public async Task<IActionResult> GetAllForAdmin() 
            => Ok(await _countryService.GetAllForAdmin());
        
        
        
        [HttpPut]
        public async Task<IActionResult> SetActive(ActivateCountryIdsDto countryIdsDtos) 
            => Ok(await _countryService.SetActive(countryIdsDtos));
        
    }
}
