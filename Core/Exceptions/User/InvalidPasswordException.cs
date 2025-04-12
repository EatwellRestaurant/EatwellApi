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
        /// Girdiğiniz şifre hatalı. Lütfen tekrar deneyin.
        /// </summary>
        public InvalidPasswordException() : base("Girdiğiniz şifre hatalı. Lütfen tekrar deneyin.")
        {
        }
    }
}
