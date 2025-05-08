using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Reservation
{
    public class NoAvailableTableException : BadRequestBaseException
    {
        /// <summary>
        /// Rezervasyon için uygun masa bulunamadı.
        /// </summary>
        public NoAvailableTableException() : base("Rezervasyon için uygun masa bulunamadı.")
        {
        }
    }
}
