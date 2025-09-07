using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Employee
{
    public class BranchAlreadyHasManagerException : BadRequestBaseException
    {
        /// <summary>
        /// Her şubenin tek bir yöneticisi olabilir!
        /// </summary>
        public BranchAlreadyHasManagerException() : base("Her şubenin tek bir yöneticisi olabilir!")
        {
        }
    }
}
