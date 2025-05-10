using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Filters
{
    public class ReservationFilter
    {
        public string? FullName { get; set; }

        public int? TableId { get; set; }

        public DateRangeFilter DateRangeFilter { get; set; }
    }
}
