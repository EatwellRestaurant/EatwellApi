using Entities.Enums.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Employee
{
    public class EmployeeFilterRequestDto
    {
        public string? FullName { get; set; }

        public WorkStatusType? WorkStatus { get; set; }

        public int? OperationClaimId { get; set; }
    }
}
