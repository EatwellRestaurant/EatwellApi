using Core.ResponseModels;
using Entities.Dtos.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPermissionService
    {
        Task<CreateSuccessResponse> Add(PermissionUpsertDto permissionUpsertDto);

        Task<DataResponse<List<PermissionListDto>>> GetAllByEmployeeAndYearAsync(int employeeId, PermissionFilterRequestDto permissionFilterRequestDto);
    }
}
