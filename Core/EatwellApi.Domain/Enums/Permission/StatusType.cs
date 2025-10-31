using System.ComponentModel.DataAnnotations;

namespace EatwellApi.Domain.Enums.Permission
{
    public enum StatusType : byte
    {
        [Display(Name = "Beklemede")]
        Pending = 1,

        [Display(Name = "Onaylandı")]
        Approved = 2,

        [Display(Name = "Reddedildi")]
        Rejected = 3,
    }
}
