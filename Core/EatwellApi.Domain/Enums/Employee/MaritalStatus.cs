using System.ComponentModel.DataAnnotations;

namespace EatwellApi.Domain.Enums.Employee
{
    public enum MaritalStatus : byte
    {
        [Display(Name = "Bekar")]
        Single = 1,

        [Display(Name = "Evli")]
        Married = 2,
    }

}
