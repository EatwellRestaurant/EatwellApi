using EatwellApi.Application.Features.Queries.MealCategories.GetActive;
using EatwellApi.Application.Features.Queries.MealCategories.GetAll;
using EatwellApi.Application.Features.Queries.MealCategories.GetLookup;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatwellApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealCategoriesController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;



        [HttpGet("lookup")]
        public async Task<IActionResult> GetLookup()
            => Ok(await _mediator.Send(new GetLookupMealCategoryQueryRequest()));
        
        
        
        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMealCategoriesQueryRequest request)
            => Ok(await _mediator.Send(request));
        
        
        
        [HttpGet("active")]
        public async Task<IActionResult> GetActive([FromQuery] GetActiveMealCategoriesQueryRequest request)
            => Ok(await _mediator.Send(request));
    
    }
}
