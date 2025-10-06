using System.ComponentModel.DataAnnotations;

namespace Entities.Enums.EmployeeTask
{
    public enum PriorityLevelEnum : byte
    {
        [Display(Name = "Düşük")]
        Low = 1,

        [Display(Name = "Orta")]
        Medium = 2, 

        [Display(Name = "Yüksek")]
        High = 3,

        [Display(Name = "Acil")]
        Urgent = 4
    }
}
