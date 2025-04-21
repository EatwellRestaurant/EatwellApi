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
            => _branchService = branchService;
        


        [HttpPost]
        public async Task<IActionResult> Add(BranchUpsertDto upsertDto) 
            => Ok(await _branchService.Add(upsertDto));



        [HttpDelete]
        public async Task<IActionResult> Delete(int branchId) 
            => Ok(await _branchService.Delete(branchId));



        [HttpPut]
        public async Task<IActionResult> Update(int branchId, BranchUpsertDto upsertDto) 
            => Ok(await _branchService.Update(branchId, upsertDto));



        [HttpGet]
        public async Task<IActionResult> GetForAdmin(int branchId) 
            => Ok(await _branchService.GetForAdmin(branchId));



        [HttpGet] 
        public async Task<IActionResult> GetAllForAdmin() 
            => Ok(await _branchService.GetAllForAdmin());
    }
}
