using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.User
{
    public class InvalidCredentialsException : BadRequestBaseException
    {
        /// <summary>
        /// Girmiş olduğunuz bilgilere ait bir hesap bulunamadı. Lütfen e-posta ve şifre bilgilerinizi kontrol ederek tekrar deneyiniz.
        /// </summary>
        public InvalidCredentialsException()
            : base("Girmiş olduğunuz bilgilere ait bir hesap bulunamadı. Lütfen e-posta ve şifre bilgilerinizi kontrol ederek tekrar deneyiniz.")
        {
        }
    }
}
