using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Branch
{
    public class MonthlySalesDto
    {
        public byte MonthId { get; set; }

        public string MonthName { get; set; }

        public decimal Sales { get; set; }
    }
}
