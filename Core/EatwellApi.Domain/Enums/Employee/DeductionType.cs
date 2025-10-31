using System.ComponentModel.DataAnnotations;

namespace EatwellApi.Domain.Enums.Employee
{
    public enum DeductionType
    {
        [Display(Name = "SGK Primi")]
        SocialSecurity = 1,

        [Display(Name = "Gelir Vergisi")]
        IncomeTax = 2,

        [Display(Name = "İşsizlik Sigortası")]
        UnemploymentInsurance = 3,

        [Display(Name = "Sendika Aidatı")]
        UnionFee = 4,

        [Display(Name = "Özel Sağlık Sigortası")]
        PrivateHealthInsurance = 5,

        [Display(Name = "Diğer Kesintiler")]
        Other = 6
    }
}
