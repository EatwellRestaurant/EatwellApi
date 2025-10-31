using System.ComponentModel.DataAnnotations;

namespace EatwellApi.Domain.Enums.Employee
{
    public enum BonusType
    {
        [Display(Name = "Performans primi")]
        Performance = 1,

        [Display(Name = "Vardiya primi")]
        Shift = 2,

        [Display(Name = "Hafta sonu çalışma primi")]
        Weekend = 3,

        [Display(Name = "Fazla mesai primi")]
        Overtime = 4,

        [Display(Name = "Resmi tatil çalışma primi")]
        Holiday = 5,

        [Display(Name = "Satış primi")]
        Sales = 6,

        [Display(Name = "Proje tamamlama primi")]
        ProjectCompletion = 7,

        [Display(Name = "Çalışan yönlendirme primi")]
        Referral = 8,

        [Display(Name = "Özel / Tek seferlik prim")]
        Special = 9
    }

}