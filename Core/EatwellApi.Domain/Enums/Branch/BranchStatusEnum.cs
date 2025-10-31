using System.ComponentModel.DataAnnotations;

namespace EatwellApi.Domain.Enums.Branch
{
    public enum BranchStatusEnum : byte
    {
        [Display(Name = "Açıldı")]
        Opened = 1,

        [Display(Name = "Onay Bekliyor")]
        AwaitingApproval = 2,

        [Display(Name = "Planlama Aşamasında")]
        Planning = 3,

        [Display(Name = "Kurulum Aşamasında")]
        Installation = 4,
    }
}
