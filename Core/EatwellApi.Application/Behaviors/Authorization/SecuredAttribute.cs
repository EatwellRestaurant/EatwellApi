using EatwellApi.Domain.Enums.OperationClaim;

namespace EatwellApi.Application.Behaviors.Authorization
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class SecuredAttribute : Attribute
    {
        public string[] Roles { get; }

        public SecuredAttribute(params OperationClaimEnum[] claims)
        {
            Roles = claims.Select(c => c.ToString()).ToArray();
        }
    }
}
