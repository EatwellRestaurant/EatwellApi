using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.ShiftDay
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
