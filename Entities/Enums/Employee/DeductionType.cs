using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums.Employee
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
