using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.ShiftDay
{
    public class IncompleteShiftScheduleException : BadRequestBaseException
    {
        /// <summary>
        /// Lütfen çalışma programını tamamlayın. Eksik günler: {days}
        /// </summary>
        public IncompleteShiftScheduleException(string days) : base($"Lütfen çalışma programını tamamlayın. Eksik günler: {days}")
        {
        }
    }
}
