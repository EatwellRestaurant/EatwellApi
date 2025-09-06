using System.ComponentModel.DataAnnotations;

namespace Entities.Enums.OperationClaim
{
    public enum OperationClaimEnum
    {
        /*
         [Display] attribute'u UI veya response tarafında gösterilecek metni özelleştirmeye yarar. 
         Yani entity’nin/enum’un kendi ismini değiştirmeden, kullanıcıya farklı şekilde gösterebiliyoruz.
         */

        Admin = 1,

        [Display(Name = "Kullanıcı")]
        User = 2,

        [Display(Name = "Yönetici")]
        Manager = 3,

        [Display(Name = "Şef")]
        Chef = 4,

        [Display(Name = "Garson")]
        Waiter = 5,

        [Display(Name = "Kurye")]
        Delivery = 6,

        [Display(Name = "Kasiyer")]
        Cashier = 7
    }

}
