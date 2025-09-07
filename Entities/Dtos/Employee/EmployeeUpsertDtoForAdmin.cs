using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Employee
{
    public class EmployeeUpsertDtoForAdmin : EmployeeUpsertDto
    {
        public int BranchId { get; set; }
    }
}
