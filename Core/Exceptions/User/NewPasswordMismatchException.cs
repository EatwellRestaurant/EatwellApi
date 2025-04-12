using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.User
{
    public class NewPasswordMismatchException : BadRequestBaseException
    {
        /// <summary>
        /// Yeni şifre ile şifre tekrarı eşleşmiyor. Lütfen kontrol edip tekrar deneyin.
        /// </summary>
        public NewPasswordMismatchException() : base("Yeni şifre ile şifre tekrarı eşleşmiyor. Lütfen kontrol edip tekrar deneyin.")
        {
        }
    }
}
