using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.User
{
    public class InvalidPasswordException : BadRequestBaseException
    {
        /// <summary>
        /// Mevcut şifreniz hatalı. Lütfen tekrar deneyin.
        /// </summary>
        public InvalidPasswordException() : base("Mevcut şifreniz hatalı. Lütfen tekrar deneyin.")
        {
        }
    }
}
