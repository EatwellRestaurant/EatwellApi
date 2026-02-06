using EatwellApi.Application.Features.Commands.User.Login;
using EatwellApi.Application.Features.Commands.User.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EatwellApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController : Controller
    {
        readonly IMediator _mediator;

        public AuthsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
            => Ok(await _mediator.Send(loginCommandRequest));




        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest registerCommandRequest)
            => Ok(await _mediator.Send(registerCommandRequest));



        //[HttpPost]
        //public async Task<IActionResult> VerifyEmailOfUser(int userId, VerificationCodeDto codeDto)
        //    => Ok(await _mediator.VerifyEmailOfUser(userId, codeDto));



        //[HttpPost]
        //public async Task<IActionResult> SendEmailAsync(int userId)
        //    => Ok(await _mediator.SendEmailAsync(userId));

    }
}
