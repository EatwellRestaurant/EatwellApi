using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Order
{
    public class OrderAlreadyPaidException : BadRequestBaseException
    {
        /// <summary>
        /// Bu sipariş zaten ödenmiş!
        /// </summary>
        public OrderAlreadyPaidException() : base("Bu sipariş zaten ödenmiş!")
        {
        }
    }
}
