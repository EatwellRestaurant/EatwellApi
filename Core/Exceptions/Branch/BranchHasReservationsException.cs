using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Branch
{
    public class BranchHasReservationsException : BadRequestBaseException
    {
        /// <summary>
        /// Bu şubeye ait rezervasyon olduğu için silinemez!
        /// </summary>
        public BranchHasReservationsException() : base("Bu şubeye ait rezervasyon olduğu için silinemez!")
        {
        }
    }
}
