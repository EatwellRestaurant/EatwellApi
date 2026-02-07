using EatwellApi.Application.Features.Queries.Product.GetBySelection;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatwellApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;



        [HttpGet]
        public async Task<IActionResult> GetProductsBySelectionStatusAsync([FromQuery] GetBySelectionStatusQueryRequest statusQueryRequest)
            => Ok(await _mediator.Send(statusQueryRequest));
    }
}
