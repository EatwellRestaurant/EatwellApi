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
        /// Girmiş olduğunuz mevcut şifreniz hatalı. Lütfen tekrar deneyin.
        /// </summary>
        public InvalidPasswordException() : base("Girmiş olduğunuz mevcut şifreniz hatalı. Lütfen tekrar deneyin.")
        {
        }
    }
}
