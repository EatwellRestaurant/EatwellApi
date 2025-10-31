using System.ComponentModel.DataAnnotations;

namespace EatwellApi.Domain.Enums.Employee
{
    public enum MilitaryStatus : byte
    {
        [Display(Name = "Yapıldı")]
        Completed = 1,

        [Display(Name = "Muaf")]
        Exempt = 2,

        [Display(Name = "Tecilli")]
        Deferred = 3,

        [Display(Name = "Yapılmadı")]
        NotDone = 4,
    }

}
