using System.ComponentModel.DataAnnotations;

namespace EatwellApi.Domain.Enums.EmployeeTask
{
    public enum TaskStatusEnum : byte
    {
        [Display(Name = "Beklemede")]
        Pending = 1,

        [Display(Name = "Devam Ediyor")]
        InProgress = 2,

        [Display(Name = "Tamamlandı")]
        Completed = 3,

        [Display(Name = "İptal")]
        Cancelled = 4
    }
}
