using EatwellApi.Domain.Entities.Common;

namespace EatwellApi.Domain.Entities
{
    public class EmployeeSubTask : BaseEntity
    {
        public int EmployeeTaskId { get; set; }

        public string Name { get; set; }

        public DateTime? CompletedDate { get; set; }





        public EmployeeTask EmployeeTask { get; set; }
    }
}
