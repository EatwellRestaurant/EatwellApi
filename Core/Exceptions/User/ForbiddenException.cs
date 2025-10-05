using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.User
{
    public class ForbiddenException : BadRequestBaseException
    {
        /// <summary>
        /// Yetkiniz yok!
        /// </summary>
        public ForbiddenException() : base("Yetkiniz yok!")
        {
        }


        public ForbiddenException(string message) : base(message) 
        { 
        }
    }
}
