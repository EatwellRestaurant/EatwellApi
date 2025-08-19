using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : BaseEntity
    {
        public Order() 
        { 
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int BranchId { get; set; }

        public int TableId { get; set; }

        public int? ReservationId { get; set; }

        public decimal TotalPrice { get; set; }

        public bool IsPaid { get; set; }

        public byte? PaymentMethod { get; set; }





        public Branch Branch { get; set; }
        public Table Table { get; set; }
        public Reservation Reservation { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    } 
}
