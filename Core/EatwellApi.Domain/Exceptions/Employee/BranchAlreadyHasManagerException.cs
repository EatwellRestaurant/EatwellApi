using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.Employee
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
