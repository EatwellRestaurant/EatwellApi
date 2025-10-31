using EatwellApi.Domain.Entities;
using EatwellApi.Domain.Security;

namespace EatwellApi.Application.Abstractions.Security
{
    public interface ITokenHelper
    {
        //Bu metotla, token'ın kim için oluşturulacağını ve içerisine hangi yetkileri koyacağımızı belirleriz.
        AccessToken CreateToken(User user, string operationClaimName);
    }
}
