using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Reservation
{
    public class ReservationAlreadyExistsException : BadRequestBaseException
    {
        public ReservationAlreadyExistsException() : base("Bu tarih için bir rezervasyon bulunuyor. Lütfen başka bir tarih seçiniz.")
        {
        }
    }
}
