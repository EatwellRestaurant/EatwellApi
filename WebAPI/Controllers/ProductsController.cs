using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.Dtos.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductUpsertDto upsertDto) 
            => Ok(await _productService.Add(upsertDto));



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
        public async Task<IActionResult> Update(int productId, [FromForm] ProductUpsertDto upsertDto) 
            => Ok(await _productService.Update(productId, upsertDto));



        [HttpGet]
        public async Task<IActionResult> GetForAdmin(int productId) 
            => Ok(await _productService.GetForAdmin(productId));

         

        [HttpGet] 
        public async Task<IActionResult> GetAllForAdminByMealCategoryId(int mealCategoryId) 
            => Ok(await _productService.GetAllForAdminByMealCategoryId(mealCategoryId));



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
