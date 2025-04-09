using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm(Name = "Image")] IFormFile file, [FromForm] ProductForCreateDto product)
        {
            var result = await _productService.Add(file, product);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm(Name = "Image")] IFormFile file, [FromBody] ProductForUpdateDto product)
        {
            var result = _productService.Update(file, product);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productService.Get(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet] 
        public async Task<IActionResult> GetProductsByMealCategoryId(int id)
        {
            var result = await _productService.GetProductsByMealCategoryId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
