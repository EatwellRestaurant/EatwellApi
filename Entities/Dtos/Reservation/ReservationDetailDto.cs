using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Reservation
{
    public class ReservationDetailDto : ReservationListDto
    {
        public string Email { get; set; }

        public string? Note { get; set; }

    }
}
