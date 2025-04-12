using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.User
{
    public class InvalidVerificationCodeException : BadRequestBaseException
    {
        /// <summary>
        /// Girdiğiniz doğrulama kodu hatalı veya süresi dolmuş. Lütfen tekrar deneyin.
        /// </summary>
        public InvalidVerificationCodeException() : base("Girdiğiniz doğrulama kodu hatalı veya süresi dolmuş. Lütfen tekrar deneyin veya yeni bir kod isteyin.")
        {
        }
    }
}
