using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.User
{
    public class UnauthorizedException : UnauthorizedBaseException
    {
        /// <summary>
        /// Oturum doğrulanamadı!
        /// </summary>
        public UnauthorizedException() : base("Oturum doğrulanamadı!") { }


        public UnauthorizedException(string message) : base(message) { }
    }
}
