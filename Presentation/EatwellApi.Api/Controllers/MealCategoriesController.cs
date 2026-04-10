using EatwellApi.Application.Features.Queries.MealCategory.GetActive;
using EatwellApi.Application.Features.Queries.MealCategory.GetActiveForDisplay;
using EatwellApi.Application.Features.Queries.MealCategory.GetAll;
using EatwellApi.Application.Features.Queries.MealCategory.GetById;
using EatwellApi.Application.Features.Queries.MealCategory.GetLookup;
using EatwellApi.Application.Parameters;
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



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromQuery] PaginationRequest request)
        {
            GetMealCategoryByIdQueryRequest query = new()
            {
                Id = id,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            return Ok(await _mediator.Send(query));
        }



        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMealCategoriesQueryRequest request)
            => Ok(await _mediator.Send(request));



        [HttpGet("active/display")]
        public async Task<IActionResult> GetActiveForDisplay([FromQuery] GetActiveMealCategoriesForDisplayQueryRequest request)
            => Ok(await _mediator.Send(request));
        
        
         
        [HttpGet("active")]
        public async Task<IActionResult> GetActive([FromQuery] GetActiveMealCategoriesQueryRequest request)
            => Ok(await _mediator.Send(request));
    
    }
}
