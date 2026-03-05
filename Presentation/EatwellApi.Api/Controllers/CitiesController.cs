using EatwellApi.Application.Features.Queries.City.GetAll;
using EatwellApi.Application.Features.Queries.City.GetLookup;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatwellApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;



        [HttpGet("lookup")]
        public async Task<IActionResult> GetLookup()
            => Ok(await _mediator.Send(new GetLookupCityQueryRequest())); 
        
        
        
        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCitiesQueryRequest request)
            => Ok(await _mediator.Send(request));
    }
} 
