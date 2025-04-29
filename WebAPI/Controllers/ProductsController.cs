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
            => _productService = productService;
        



        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductInsertDto insertDto) 
            => Ok(await _productService.Add(insertDto));



        [HttpDelete]
        public async Task<IActionResult> Delete(int productId) 
            => Ok(await _productService.Delete(productId));



        [HttpPut]
        public async Task<IActionResult> Update(int productId, [FromForm] ProductUpdateDto updateDto) 
            => Ok(await _productService.Update(productId, updateDto));



        [HttpGet]
        public async Task<IActionResult> GetForAdmin(int productId) 
            => Ok(await _productService.GetForAdmin(productId));

         

        [HttpGet] 
        public async Task<IActionResult> GetAllForAdminByMealCategoryId(int mealCategoryId) 
            => Ok(await _productService.GetAllForAdminByMealCategoryId(mealCategoryId));
        
       

        [HttpGet] 
        public async Task<IActionResult> GetAllForAdmin() 
            => Ok(await _productService.GetAllForAdmin());



        [HttpDelete]
        public async Task<IActionResult> SetDeleteOrRestore(int productId)
            => Ok(await _productService.SetDeleteOrRestore(productId));
    }
}
