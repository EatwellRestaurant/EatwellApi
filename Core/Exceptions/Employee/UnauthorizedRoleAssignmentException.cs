using Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Employee
{
    public class UnauthorizedRoleAssignmentException : BadRequestBaseException
    {
        /// <summary>
        /// {currentUserRole} yetkisine sahip kullanıcı, {targetRole} rolünde çalışan oluşturamaz!
        /// </summary>
        public UnauthorizedRoleAssignmentException(string currentUserRole, string targetRole) : base($"{currentUserRole} yetkisine sahip kullanıcı, {targetRole.ToLower()} rolünde çalışan oluşturamaz!")
        {
        }
    }
}
