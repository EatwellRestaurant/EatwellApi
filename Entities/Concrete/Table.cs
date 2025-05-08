using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Table : BaseEntity
    {
        public int BranchId { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public byte Capacity { get; set; }



        public Branch Branch { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
