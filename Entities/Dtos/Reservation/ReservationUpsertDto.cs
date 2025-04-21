using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Reservation
{
    public class ReservationUpsertDto : IDto
    {
        public int BranchId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public DateTime ReservationDate { get; set; }
        
        public int PersonCount { get; set; }
        
        public string? Note { get; set; }
    }
}
