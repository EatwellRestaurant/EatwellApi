using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Product
{
    public class DuplicateProductOrderException : BadRequestBaseException
    {
        /// <summary>
        /// Aynı sıralama değerine sahip birden fazla ürün var!
        /// </summary>
        public DuplicateProductOrderException() : base("Aynı sıralama değerine sahip birden fazla ürün var!")
        {
        }
    }
}
