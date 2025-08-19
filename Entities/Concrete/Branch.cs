using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Branch : BaseEntity
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? WebSite { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Gmail { get; set; }

         


        public City City { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<BranchEmployee> BranchEmployees { get; set; }
        public ICollection<BranchImage> BranchImages { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Table> Tables { get; set; }


    }
}
