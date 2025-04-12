using Business.Abstract;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll() 
            => Ok(await _userService.GetAll());
        
        
        
        [HttpGet]
        [Authorize] 
        public async Task<IActionResult> Get(int userId) 
            => Ok(await _userService.Get(userId));
        
        
        
        [HttpPut] 
        [Authorize] 
        public async Task<IActionResult> Update(int userId, UserUpdateDto updateDto) 
            => Ok(await _userService.Update(userId, updateDto));
    }
}
