using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.User
{
    public class InvalidVerificationCodeException : BadRequestBaseException
    {
        /// <summary>
        /// Girdiğiniz doğrulama kodu hatalı veya süresi dolmuş. Lütfen tekrar deneyin.
        /// </summary>
        public InvalidVerificationCodeException() : base("Girdiğiniz doğrulama kodu hatalı veya süresi dolmuş. Lütfen tekrar deneyin veya yeni bir kod isteyin.")
        {
        }
    }
}
