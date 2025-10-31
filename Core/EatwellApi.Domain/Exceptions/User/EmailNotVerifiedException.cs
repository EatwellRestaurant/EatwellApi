using EatwellApi.Domain.Exceptions.Bases;

namespace EatwellApi.Domain.Exceptions.User
{
    public class EmailNotVerifiedException : BadRequestBaseException
    {
        /// <summary>
        /// E-posta adresiniz henüz doğrulanmamış. Lütfen e-posta kutunuzu kontrol edin ve doğrulamayı tamamlayın.
        /// </summary>
        public EmailNotVerifiedException() : base("E-posta adresiniz henüz doğrulanmamış. Lütfen e-posta kutunuzu kontrol edin ve doğrulamayı tamamlayın.")
        {
        }
    }
}
