using System.ComponentModel.DataAnnotations;

namespace EatwellApi.Domain.Enums.Employee
{
    public enum EmploymentType : byte
    {
        [Display(Name = "Tam Zamanlı")]
        FullTime = 1,

        [Display(Name = "Yarı Zamanlı")]
        PartTime = 2,

        [Display(Name = "Stajyer")]
        Intern = 3,

        [Display(Name = "Sözleşmeli")]
        Contract = 4
    }
}
