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
        [Authorize]
        public async Task<IActionResult> Update(int mealCategoryId, [FromForm] MealCategoryUpsertDto upsertDto) 
            => Ok(await _mealCategoryService.Update(mealCategoryId, upsertDto));
        


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
