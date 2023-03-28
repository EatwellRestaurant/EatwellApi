using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageCategoriesController : ControllerBase
    {
        private IImageCategoryService _imageCategoryService;

        public ImageCategoriesController(IImageCategoryService imageCategoryService)
        {
            _imageCategoryService = imageCategoryService;
        }

        [HttpPost("add")]
        public IActionResult Add(ImageCategory imageCategory)
        {
            var result = _imageCategoryService.Add(imageCategory);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ImageCategory imageCategory)
        {
            var result = _imageCategoryService.Delete(imageCategory);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ImageCategory imageCategory)
        {
            var result = _imageCategoryService.Update(imageCategory);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _imageCategoryService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _imageCategoryService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
