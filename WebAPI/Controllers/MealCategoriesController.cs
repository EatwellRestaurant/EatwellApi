using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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

        [HttpPut]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] MealCategory mealCategory)
        {
            var result = _mealCategoryService.Add(file, mealCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(MealCategory mealCategory)
        {
            var result = _mealCategoryService.Delete(mealCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file,[FromForm] MealCategory mealCategory)
        {
            var result = _mealCategoryService.Update(file, mealCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _mealCategoryService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _mealCategoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
