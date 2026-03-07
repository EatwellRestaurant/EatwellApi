using EatwellApi.Application.Behaviors.Authorization;
using EatwellApi.Application.Behaviors.Cache;
using EatwellApi.Application.Behaviors.Validation;
using EatwellApi.Application.Mapping;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EatwellApi.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile).Assembly);
            services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly);
            });


            // Pipeline sıralamasının bu şekilde olması gerekiyor. Öncelikle yetkilendirme,
            // ardından doğrulama ve son olarak önbellekleme işlemi gerçekleştirilir.

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehavior<,>));
        }
    }
}
