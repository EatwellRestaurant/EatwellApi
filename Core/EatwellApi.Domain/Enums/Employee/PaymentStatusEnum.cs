using System.ComponentModel.DataAnnotations;

namespace EatwellApi.Domain.Enums.Employee
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
