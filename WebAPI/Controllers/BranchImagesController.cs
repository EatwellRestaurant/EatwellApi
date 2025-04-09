using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchImagesController : ControllerBase
    {
        private IBranchImageService _branchImageService;

        public BranchImagesController(IBranchImageService branchImageService)
        {
            _branchImageService = branchImageService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm(Name = "Image")]IFormFile file, [FromForm]BranchImage branchImage)
        {
            var result = await _branchImageService.Add(file, branchImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(BranchImage branchImage)
        {
            var result = _branchImageService.Delete(branchImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm(Name = "Image")]IFormFile file, [FromForm]BranchImage branchImage)
        {
            var result = _branchImageService.Update(file, branchImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _branchImageService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _branchImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
