using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class HeadOffice : IEntity
    {
        public int Id { get; set; }
        
        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        
        public string MidWeekWorkingHours { get; set; }
        
        public string WeekendWorkingHours { get; set; }

        public string? SpecialNote { get; set; }

        public string? Facebook { get; set; }
        
        public string? Instagram { get; set; }
        
        public string? Twitter { get; set; }

        public string? Gmail { get; set; }
    }
}
