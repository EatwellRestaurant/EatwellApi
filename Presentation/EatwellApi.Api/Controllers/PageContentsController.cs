using EatwellApi.Application.Features.Queries.PageContent.GetByPage;
using EatwellApi.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatwellApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageContentsController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;



        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageEnum pageEnum)
            => Ok(await _mediator.Send(new GetPageContentByPageQueryRequest(pageEnum)));
    }
}
