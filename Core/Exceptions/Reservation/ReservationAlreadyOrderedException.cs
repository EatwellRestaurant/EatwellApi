using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Reservation
{
    public class ReservationAlreadyOrderedException : BadRequestBaseException
    {
        /// <summary>
        /// Bu rezervasyon için zaten sipariş verilmiş!
        /// </summary>
        public ReservationAlreadyOrderedException() : base("Bu rezervasyon için zaten sipariş verilmiş!")
        {
        }
    }
}
