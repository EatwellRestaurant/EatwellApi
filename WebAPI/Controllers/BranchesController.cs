using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Branch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService) 
            => _branchService = branchService;
        


        [HttpPost]
        public async Task<IActionResult> Add(BranchInsertDto insertDto) 
            => Ok(await _branchService.Add(insertDto));



        [HttpDelete]
        public async Task<IActionResult> Delete(int branchId) 
            => Ok(await _branchService.Delete(branchId));



        [HttpPut]
        public async Task<IActionResult> Update(int branchId, BranchUpdateDto updateDto) 
            => Ok(await _branchService.Update(branchId, updateDto));



        [HttpGet]
        public async Task<IActionResult> GetForAdmin(int branchId) 
            => Ok(await _branchService.GetForAdmin(branchId));



        [HttpGet] 
        public async Task<IActionResult> GetAllForAdmin() 
            => Ok(await _branchService.GetAllForAdmin());
    }
}
