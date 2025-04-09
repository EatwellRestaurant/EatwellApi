using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchsController : ControllerBase
    {
        private IBranchService _branchService;

        public BranchsController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Branch branch)
        {
            var result = await _branchService.Add(branch);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(Branch branch)
        {
            var result = _branchService.Delete(branch);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Branch branch)
        {
            var result = _branchService.Update(branch);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _branchService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _branchService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
