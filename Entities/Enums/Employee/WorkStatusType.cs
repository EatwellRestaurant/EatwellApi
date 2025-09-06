using System.ComponentModel.DataAnnotations;

namespace Entities.Enums.Employee
{
    public enum WorkStatusType : byte
    {
        [Display(Name = "Aktif")]
        Active = 1,

        [Display(Name = "İzinli")]
        OnLeave = 2,

        [Display(Name = "İşten Ayrılmış")]
        Resigned = 3

    }
}
