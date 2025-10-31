using System.ComponentModel.DataAnnotations;

namespace EatwellApi.Domain.Enums.Employee
{
    public enum GenderType : byte
    {
        [Display(Name = "Erkek")]
        Male = 1,

        [Display(Name = "Kadın")]
        Female = 2
    }
}
