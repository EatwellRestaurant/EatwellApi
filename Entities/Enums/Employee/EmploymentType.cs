using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums.Employee
{
    public enum EmploymentType : byte
    {
        [Display(Name = "Tam Zamanlı")]
        FullTime = 1,

        [Display(Name = "Yarı Zamanlı")]
        PartTime = 2,
        
        [Display(Name = "Stajyer")]
        Intern = 3,  

        [Display(Name = "Sözleşmeli")]
        Contract = 4 
    }
}
