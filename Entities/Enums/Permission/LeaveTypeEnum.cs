using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums.Permission
{
    public enum LeaveTypeEnum 
    {
        [Display(Name = "Yıllık İzin")]
        AnnualLeave = 1,

        [Display(Name = "Mazeret İzni")]
        ExcuseLeave = 2,

        [Display(Name = "Ücretsiz İzin")]
        UnpaidLeave = 3,

        [Display(Name = "Hastalık İzni")]
        SickLeave = 4,

        [Display(Name = "Doğum İzni")]
        MaternityLeave = 5,

        [Display(Name = "Babalık İzni")]
        PaternityLeave = 6,

        [Display(Name = "Evlilik İzni")]
        MarriageLeave = 7,

        [Display(Name = "Cenaze İzni")]
        BereavementLeave = 8
    }
}
