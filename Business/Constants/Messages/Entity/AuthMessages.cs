using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages.Entity
{
    public class AuthMessages
    {
        public const string UserRegistered = "Kullanıcı başarıyla kaydedildi.";
        public const string UserNotFound = "Kullanıcı bulunamadı";
        public const string PasswordError = "Şifre hatalı";
        public const string SuccessfulLogin = "Sisteme Giriş Başarılı";
        public const string UserAlreadyExists = "Böyle bir kullanıcı zaten var";
        public const string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public const string VerificationSuccessful = "E-posta adresiniz başarıyla doğrulandı. Şimdi hesabınıza giriş yapabilirsiniz.";
    }
}
