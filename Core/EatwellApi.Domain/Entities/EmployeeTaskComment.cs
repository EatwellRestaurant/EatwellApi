using EatwellApi.Domain.Entities.Common;

namespace EatwellApi.Domain.Entities
{
    public class EmployeeTaskComment : BaseEntity
    {
        public int EmployeeId { get; set; }

        public int EmployeeTaskId { get; set; }

        public string Comment { get; set; }





        public Employee Employee { get; set; }
        public EmployeeTask EmployeeTask { get; set; }
    }
}
