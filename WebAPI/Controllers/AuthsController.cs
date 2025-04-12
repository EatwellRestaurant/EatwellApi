using Business.Abstract;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController : Controller
    {
        private IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto) 
            => Ok(await _authService.Login(userForLoginDto));
            
        


        [HttpPost]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto) 
            => Ok(await _authService.Register(userForRegisterDto));
        
        

        [HttpPost] 
        public async Task<IActionResult> VerifyEmailOfUser(int userId, VerificationCodeDto codeDto) 
            => Ok(await _authService.VerifyEmailOfUser(userId, codeDto));
        
        

        [HttpPost] 
        public async Task<IActionResult> SendEmailAsync(int userId) 
            => Ok(await _authService.SendEmailAsync(userId));
            
    }
}
