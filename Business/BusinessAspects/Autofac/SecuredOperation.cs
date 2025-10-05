using Castle.DynamicProxy;
using Core.Exceptions.User;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Entities.Concrete;
using Entities.Enums.OperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Business.BusinessAspects.Autofac
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
