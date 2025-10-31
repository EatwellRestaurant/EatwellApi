using AutoMapper;
using EatwellApi.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace EatwellApi.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile).Assembly);


            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapProfile());
            })
            .CreateMapper());
        }
    }
}
