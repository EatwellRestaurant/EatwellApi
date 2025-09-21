using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Permission
{
    public class OverlappingLeaveRequestException : BadRequestBaseException
    {
        /// <summary>
        /// Çalışan, seçilen tarihlerde daha önce izin kullanmıştır. Lütfen farklı bir tarih aralığı seçiniz.
        /// </summary>
        public OverlappingLeaveRequestException() : base("Çalışan, seçilen tarihlerde daha önce izin kullanmıştır. Lütfen farklı bir tarih aralığı seçiniz.")
        {
        }
    }
}
