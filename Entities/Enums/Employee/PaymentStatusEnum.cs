using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums.Employee
{
    public enum PaymentStatusEnum
    {
        [Display(Name = "Beklemede")]
        Pending = 1,

        [Display(Name = "Onaylandı")]
        Approved = 2,

        [Display(Name = "Ödendi")]
        Paid = 3,

        [Display(Name = "Reddedildi")]
        Rejected = 4,

        [Display(Name = "İptal Edildi")]
        Cancelled = 5,

        [Display(Name = "Ödeme Başarısız")]
        Failed = 6
    }

}
