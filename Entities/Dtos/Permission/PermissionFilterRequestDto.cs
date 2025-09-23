using Core.Entities.Abstract;
using Entities.Enums.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Permission
{
    public class PermissionFilterRequestDto : IDto
    {
        public int? YearId { get; set; }

        public int? LeaveTypeId { get; set; }
    }
}
