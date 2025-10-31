using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.User
{
    public class NewPasswordMismatchException : BadRequestBaseException
    {
        /// <summary>
        /// Yeni şifre ile şifre tekrarı eşleşmiyor. Lütfen kontrol edip tekrar deneyin.
        /// </summary>
        public NewPasswordMismatchException() : base("Yeni şifre ile şifre tekrarı eşleşmiyor. Lütfen kontrol edip tekrar deneyin.")
        {
        }
    }
}
