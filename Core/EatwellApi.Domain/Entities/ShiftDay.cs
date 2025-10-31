using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Domain.Entities
{
    public class ShiftDay : IEntity
    {
        public int ShiftId { get; set; }

        public int EmployeeId { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public bool IsHoliday { get; set; }

        public bool IsLeave { get; set; }

        public DateTime? UpdateDate { get; set; }





        public Employee Employee { get; set; }
        public Shift Shift { get; set; }
    }
}
