using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.MealCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MealCategoriesController : ControllerBase
    {
        private IMealCategoryService _mealCategoryService;

        public MealCategoriesController(IMealCategoryService mealCategoryService)
        {
            _mealCategoryService = mealCategoryService;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromForm] MealCategoryUpsertDto upsertDto) 
            => Ok(await _mealCategoryService.Add(upsertDto));
        
        

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> SetDeleteOrRestore(int mealCategoryId) 
            => Ok(await _mealCategoryService.SetDeleteOrRestore(mealCategoryId));
        


        [HttpPut]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file,[FromForm] string mealCategoryName)
        {
            MealCategory mealCategory = new() { Name = mealCategoryName };
            
            var result = _mealCategoryService.Update(file, mealCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get(int mealCategoryId) 
            => Ok(await _mealCategoryService.Get(mealCategoryId));
            
        


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllForAdmin() 
            => Ok(await _mealCategoryService.GetAllForAdmin());
    }
}
