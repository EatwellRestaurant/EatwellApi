using Business.Abstract;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll() 
            => Ok(await _userService.GetAll());
        
        
        
        [HttpGet]
        public async Task<IActionResult> Get(int userId) 
            => Ok(await _userService.Get(userId));
        
        
        
        [HttpPut] 
        public async Task<IActionResult> Update(UserUpdateDto updateDto)
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(await _userService.Update(userId, updateDto));
        }
        
        
        
        [HttpPut]  
        public async Task<IActionResult> UpdatePassword(UserPasswordUpdateDto updateDto)
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(await _userService.UpdatePassword(userId, updateDto));
        }


        //POST yöntemiyle veri güvenli taşınıyor.
        [HttpPost]  
        public async Task<IActionResult> Delete([FromBody] UserDeleteDto deleteDto)
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(await _userService.Delete(userId, deleteDto));
        }
    }
}
