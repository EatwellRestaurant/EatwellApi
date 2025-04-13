using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Country
{
    public class TurkeyPassiveNotAllowedException : BadRequestBaseException
    {
        /// <summary>
        /// Türkiye, ana ülke olarak işaretlendiği için pasif duruma getirilemez.
        /// </summary>
        public TurkeyPassiveNotAllowedException() : base("Türkiye, ana ülke olarak işaretlendiği için pasif duruma getirilemez.")
        {
        }
    }
}
