using EatwellApi.Application.Features.Queries.User.GetOverview;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatwellApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersStatisticsController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;


        [HttpGet("overview")]
        public async Task<IActionResult> GetOverview()
            => Ok(await _mediator.Send(new GetUsersOverviewQueryRequest()));

    }
}
