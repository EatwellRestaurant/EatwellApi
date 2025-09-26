using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums.Employee;

namespace Entities.Concrete
{
    public class EmployeeBonus : BaseEntity
    {
        public int EmployeeId { get; set; }

        public int MonthId { get; set; }

        public BonusType BonusType { get; set; }

        public decimal Amount { get; set; }

        public PaymentStatusEnum PaymentStatus { get; set; }





        public Employee Employee { get; set; }
        public Month Month { get; set; }

    }
}
