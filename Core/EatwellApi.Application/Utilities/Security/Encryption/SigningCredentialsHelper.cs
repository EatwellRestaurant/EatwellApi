using Microsoft.IdentityModel.Tokens;

namespace EatwellApi.Application.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //Bu class ile Asp.Net'e hangi anahtarı ve algoritmayı kullanacağımızı söyleriz.
        //Parametreyle gelen securityKey'i seçilen encryption algoritması ile şifreliyoruz.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
