using EatwellApi.Application.Features.Queries.HeadOffice.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatwellApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadOfficesController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;



        [HttpGet]
        public async Task<IActionResult> GetAsync()
            => Ok(await _mediator.Send(new GetHeadOfficeQueryRequest()));
    }
}
