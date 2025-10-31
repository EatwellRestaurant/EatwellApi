using Castle.DynamicProxy;
using EatwellApi.Application.Aspects.Interceptors;
using EatwellApi.Application.Extensions;
using EatwellApi.Application.Utilities.IoC;
using EatwellApi.Domain.Enums.OperationClaim;
using EatwellApi.Domain.Exceptions.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace EatwellApi.Application.Aspects.Security
{
    public class SecuredOperation : MethodInterception
    {
        List<OperationClaimEnum> _roles;
        private IHttpContextAccessor? _httpContextAccessor;

        public SecuredOperation(params OperationClaimEnum[] roles)
        {
            _roles = roles.ToList();
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            ClaimsPrincipal? user = _httpContextAccessor.HttpContext?.User;

            if (user == null || !user.Identity.IsAuthenticated)
                throw new ForbiddenException("Kullanıcı oturumu geçersiz!");



            string? expClaim = user.FindFirst("exp")?.Value;

            if (expClaim != null && long.TryParse(expClaim, out var exp))
            {
                // Unix timestamp’i normal DateTime’a çeviriyoruz.
                DateTime expirationTime = DateTimeOffset.FromUnixTimeSeconds(exp).UtcDateTime;

                if (expirationTime < DateTime.UtcNow)
                    throw new ForbiddenException("Oturum süreniz dolmuştur!");
            }



            List<string> roleClaims = user.ClaimRoles();

            if (!_roles.Any(r => roleClaims.Select(r => r.ToLower()).Contains(r.ToString().ToLower())))
                throw new ForbiddenException();
        }
    }
}
