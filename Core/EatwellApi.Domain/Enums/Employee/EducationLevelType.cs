using System.ComponentModel.DataAnnotations;

namespace EatwellApi.Domain.Enums.Employee
{
    public enum EducationLevelType : byte
    {
        [Display(Name = "İlkokul")]
        PrimarySchool = 1,

        [Display(Name = "Ortaokul")]
        MiddleSchool = 2,

        [Display(Name = "Lise")]
        HighSchool = 3,

        [Display(Name = "Önlisans")]
        AssociateDegree = 4,

        [Display(Name = "Lisans")]
        Bachelor = 5,

        [Display(Name = "Yüksek Lisans")]
        Master = 6
    }
}
