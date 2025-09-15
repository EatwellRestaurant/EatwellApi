using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums.Employee
{
    public enum MilitaryStatus : byte 
    {
        [Display(Name = "Yapıldı")]
        Completed = 1,
        
        [Display(Name = "Muaf")]
        Exempt = 2,
        
        [Display(Name = "Tecilli")]
        Deferred = 3,
        
        [Display(Name = "Yapılmadı")]
        NotDone = 4,
    }

}
