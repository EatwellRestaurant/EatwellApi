using EatwellApi.Application.Features.Queries.Employee.GetFilterOptions;
using EatwellApi.Application.Features.Queries.Employee.GetOverview;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatwellApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeStatisticsController(IMediator mediator) : ControllerBase
    {
        readonly IMediator _mediator = mediator;



        [HttpGet("overview")]
        public async Task<IActionResult> GetOverview([FromQuery] GetEmployeesOverviewQueryRequest queryRequest)
            => Ok(await _mediator.Send(queryRequest));




        [HttpGet("filter-options")]
        public async Task<IActionResult> GetFilterOptions()
            => Ok(await _mediator.Send(new GetEmployeeFilterOptionsQueryRequest()));
    
    }
}
