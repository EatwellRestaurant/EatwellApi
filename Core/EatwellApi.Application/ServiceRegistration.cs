using EatwellApi.Application.Behaviors.Authorization;
using EatwellApi.Application.Behaviors.Cache;
using EatwellApi.Application.Behaviors.Validation;
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

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehavior<,>));
        }
    }
}
