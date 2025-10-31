using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.User
{
    public class InvalidPasswordException : BadRequestBaseException
    {
        /// <summary>
        /// Mevcut şifreniz hatalı. Lütfen tekrar deneyin.
        /// </summary>
        public InvalidPasswordException() : base("Mevcut şifreniz hatalı. Lütfen tekrar deneyin.")
        {
        }
    }
}
