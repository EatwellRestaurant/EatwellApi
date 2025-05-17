using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Table
{
    public class TableDeletionNotAllowedException : BadRequestBaseException
    {
        /// <summary>
        /// Bu masaya ait rezervasyon olduğu için silinemez!
        /// </summary>
        public TableDeletionNotAllowedException() : base("Bu masaya ait rezervasyon olduğu için silinemez!")
        {
        }
    }
}
