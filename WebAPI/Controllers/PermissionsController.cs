using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Permission;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/employees/{employeeId}/permissions")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }




        [HttpPost]
        public async Task<IActionResult> Add(int employeeId, [FromBody] PermissionUpsertDto permissionUpsertDto)
        {
            permissionUpsertDto.EmployeeId = employeeId;
            
            return Ok(await _permissionService.Add(permissionUpsertDto));
        }
        

        
        [HttpGet]
        public async Task<IActionResult> GetAllByEmployeeAndYearAsync(int employeeId, [FromQuery] PermissionFilterRequestDto permissionFilterRequestDto)
            => Ok(await _permissionService.GetAllByEmployeeAndYearAsync(employeeId, permissionFilterRequestDto));
        
    }
}
