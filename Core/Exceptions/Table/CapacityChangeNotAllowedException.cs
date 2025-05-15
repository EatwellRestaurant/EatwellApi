using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Table
{
    public class CapacityChangeNotAllowedException : BadRequestBaseException
    {
        public CapacityChangeNotAllowedException() : base("Bu masanın ileri tarihlerde rezervasyonları bulunduğu için kapasitesi değiştirilemez!")
        {
        }
    }
}
