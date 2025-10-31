using EatwellApi.Application.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace EatwellApi.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            ServiceTool.Create(services);
        }
    }
}
