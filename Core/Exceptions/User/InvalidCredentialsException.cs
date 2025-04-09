using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.User
{
    public class InvalidCredentialsException : BadRequestBaseException
    {
        /// <summary>
        /// Girmiş olduğunuz bilgilere ait bir hesap bulunamadı. Lütfen e-posta ve şifre bilgilerinizi kontrol ederek tekrar deneyiniz.
        /// </summary>
        public InvalidCredentialsException() 
            : base("Girmiş olduğunuz bilgilere ait bir hesap bulunamadı. Lütfen e-posta ve şifre bilgilerinizi kontrol ederek tekrar deneyiniz.")
        {
        }
    }
}
