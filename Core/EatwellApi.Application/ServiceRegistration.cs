using EatwellApi.Application.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EatwellApi.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile).Assembly);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly);
            });
        }
    }
}
