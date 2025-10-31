using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.ShiftDay
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
