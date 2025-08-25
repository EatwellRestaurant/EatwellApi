using Business.Abstract;
using Core.Requests;
using Core.ResponseModels;
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
        public async Task<IActionResult> GetAllForAdmin([FromQuery] PaginationRequest? paginationRequest)
        {
            if (paginationRequest!.PageNumber == 0 || paginationRequest.PageSize == 0)
                paginationRequest = null;

            return Ok(await _branchService.GetAllForAdmin(paginationRequest));
        }
        

        
        [HttpGet] 
        public async Task<IActionResult> GetAllForAdminByCityId(int cityId, [FromQuery] PaginationRequest paginationRequest) 
            => Ok(await _branchService.GetAllForAdminByCityId(cityId, paginationRequest));



        [HttpGet]
        public async Task<IActionResult> GetAllBranchesMonthlySalesAsync()
            => Ok(await _branchService.GetAllBranchesMonthlySalesAsync());

    }
}
