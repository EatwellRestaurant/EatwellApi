using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Branch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchsController : ControllerBase
    {
        readonly IBranchService _branchService;

        public BranchsController(IBranchService branchService)
        {
            _branchService = branchService;
        }


        [HttpPost]
        public async Task<IActionResult> Add(BranchUpsertDto upsertDto) 
            => Ok(await _branchService.Add(upsertDto));


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
        public async Task<IActionResult> GetAllForAdmin() 
            => Ok(await _branchService.GetAllForAdmin());
    }
}
