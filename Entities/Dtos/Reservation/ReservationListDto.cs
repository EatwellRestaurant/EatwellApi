using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Reservation
{
    public class ReservationListDto : EntityAdminDto
    {
        public int TableNo { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; } 

        public DateTime ReservationDate { get; set; }

        public byte PersonCount { get; set; }
    }
}
