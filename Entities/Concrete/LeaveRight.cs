using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class LeaveRight : IEntity
    {
        public int Id { get; set; }

        public int YearId { get; set; }

        public int LeaveTypeId { get; set; }

        public string SeniorityRange { get; set; }

        public byte DayCount { get; set; }



    }
}
