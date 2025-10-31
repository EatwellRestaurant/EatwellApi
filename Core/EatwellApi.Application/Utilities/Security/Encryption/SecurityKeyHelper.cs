using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EatwellApi.Application.Utilities.Security.Encryption
{
    //Şifreleme sistemlerinde bizim her şeyi byte array formatında oluşturmamız gerekir.
    //Yani bir string ile key oluşturamıyoruz.
    //Bu string değerleri asp.net'in jwt servislerinin anlayacağı hale getirmemiz gerekir.
    public class SecurityKeyHelper
    {
        //Parametreyle gelen WebApi katmanındaki appsettings.json dosyasındaki securityKey'i, SecurityKey formatına dönüştürüyoruz. 
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
