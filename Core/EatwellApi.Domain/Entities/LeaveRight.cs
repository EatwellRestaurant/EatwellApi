using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Domain.Entities
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
