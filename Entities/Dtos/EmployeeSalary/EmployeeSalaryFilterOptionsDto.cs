using Entities.Dtos.Branch;
using Entities.Dtos.Employee;
using Entities.Dtos.OperationClaim;
using Entities.Dtos.Year;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.EmployeeSalary
{
    public class EmployeeSalaryFilterOptionsDto
    {
        public List<YearListDto> YearListDtos { get; set; }

        public List<PaymentStatusDto> PaymentStatusDtos { get; set; }
    }
}
