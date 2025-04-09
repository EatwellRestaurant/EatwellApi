using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchEmployeesController : ControllerBase
    {
        private IBranchEmployeeService _branchEmployeeService;

        public BranchEmployeesController(IBranchEmployeeService branchEmployeeService)
        {
            _branchEmployeeService = branchEmployeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm(Name = "Image")] IFormFile file, [FromForm] BranchEmployee branchEmployee)
        {
            var result = await _branchEmployeeService.Add(file, branchEmployee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(BranchEmployee branchEmployee)
        {
            var result = _branchEmployeeService.Delete(branchEmployee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm(Name = "Image")] IFormFile file, [FromForm] BranchEmployee branchEmployee)
        {
            var result = await _branchEmployeeService.Update(file, branchEmployee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _branchEmployeeService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _branchEmployeeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
