using EatwellApi.Application.Features.Queries.Reservation.GetOverview;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatwellApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationStatisticsController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;


         
        [HttpGet("overview")]
        public async Task<IActionResult> GetOverview([FromQuery] GetReservationOverviewQueryRequest request)
            => Ok(await _mediator.Send(request));
    }
}
