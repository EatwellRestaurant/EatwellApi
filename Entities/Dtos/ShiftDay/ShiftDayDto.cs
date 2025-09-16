using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.ShiftDay
{
    public class ShiftDayDto : IDto
    {
        public int ShiftId { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public bool IsHoliday { get; set; }

        public bool IsLeave { get; set; }
    }
}
