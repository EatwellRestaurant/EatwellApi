using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums.Employee
{
    public enum MaritalStatus : byte
    {
        [Display(Name = "Bekar")]
        Single = 1,

        [Display(Name = "Evli")]
        Married = 2,
    }

}
