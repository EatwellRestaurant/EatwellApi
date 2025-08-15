using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Reservation : BaseEntity
    {
        public int BranchId { get; set; }

        public int TableId { get; set; }
        
        public string FullName { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public DateTime ReservationDate { get; set; }
        
        public byte PersonCount { get; set; }
        
        public string? Note { get; set; }



        public Branch Branch { get; set; }
        public Table Table { get; set; }
        public Order Order { get; set; }


    }
}
