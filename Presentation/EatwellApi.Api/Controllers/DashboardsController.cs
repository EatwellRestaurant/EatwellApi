using EatwellApi.Application.Features.Queries.Dashboard.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatwellApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardsController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;



        [HttpGet]
        public async Task<IActionResult> GetStatistics()
            => Ok(await _mediator.Send(new GetStatisticsQueryRequest()));
    }
}
