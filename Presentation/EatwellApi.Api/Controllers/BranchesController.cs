using EatwellApi.Application.Features.Queries.Branch.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatwellApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;



        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBranchesQueryRequest request)
            => Ok(await _mediator.Send(request));
    }
}
