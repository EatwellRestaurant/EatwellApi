using EatwellApi.Application.Features.Queries.Product.GetOverview;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatwellApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStatisticsController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;



        [HttpGet("overview")]
        public async Task<IActionResult> GetOverview([FromQuery] GetProductOverviewQueryRequest request)
          => Ok(await _mediator.Send(request));
    }
}
