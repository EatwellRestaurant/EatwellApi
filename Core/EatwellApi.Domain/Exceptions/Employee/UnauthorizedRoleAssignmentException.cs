using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.Employee
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
