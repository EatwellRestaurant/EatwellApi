using Business.Abstract;
using Entities.Dtos.Permission;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }




        [HttpPost]
        public async Task<IActionResult> Add(PermissionUpsertDto permissionUpsertDto)
            => Ok(await _permissionService.Add(permissionUpsertDto));
    }
}
