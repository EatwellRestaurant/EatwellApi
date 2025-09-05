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
        /// Müdür yetkisine sahip kullanıcı, {role} rolünde çalışan oluşturamaz!
        /// </summary>
        public UnauthorizedRoleAssignmentException(string role) : base($"Müdür yetkisine sahip kullanıcı, {role} rolünde çalışan oluşturamaz!")
        {
        }
    }
}
