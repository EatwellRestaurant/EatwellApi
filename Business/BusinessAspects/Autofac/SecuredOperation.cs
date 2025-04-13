using Castle.DynamicProxy;
using Core.Exceptions.User;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        List<string> _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',').Select(role => role.Trim()).ToList();
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            List<string> roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();


            if (_roles.Any(r => roleClaims.Select(r => r.ToLower()).Contains(r.ToLower())))
                return;

            throw new ForbiddenException();
        }
    }
}
