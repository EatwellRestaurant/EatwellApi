using EatwellApi.Application.Features.Commands.User.Login;
using EatwellApi.Application.Features.Commands.User.Register;
using EatwellApi.Application.Features.Commands.User.ResendEmail;
using EatwellApi.Application.Features.Commands.User.VerifyEmail;
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




        [HttpPost]
        public async Task<IActionResult> VerifyEmailOfUser(VerifyEmailCommandRequest verifyEmailCommandRequest)
            => Ok(await _mediator.Send(verifyEmailCommandRequest));




        [HttpPost] 
        public async Task<IActionResult> ResendEmail(ResendEmailCommandRequest resendEmailCommandRequest)
            => Ok(await _mediator.Send(resendEmailCommandRequest));

    }
}
