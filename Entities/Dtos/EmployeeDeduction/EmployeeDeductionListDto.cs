using Core.Entities.Abstract;
using Entities.Enums.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.EmployeeDeduction
{
    public class EmployeeDeductionListDto : IDto
    {
        public int Id { get; set; }

        public string DeductionType { get; set; }

        public decimal Amount { get; set; }

        public PaymentStatusEnum PaymentStatus { get; set; }

        public string PaymentStatusName { get; set; }
    }
}
