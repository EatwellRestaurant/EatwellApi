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
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] BranchEmployee branchEmployee)
        {
            var result = _branchEmployeeService.Add(file, branchEmployee);
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
        public IActionResult Update([FromForm(Name = "Employee")] IFormFile file, [FromForm] BranchEmployee branchEmployee)
        {
            var result = _branchEmployeeService.Update(file, branchEmployee);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _branchEmployeeService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _branchEmployeeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
