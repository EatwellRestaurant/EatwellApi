using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Abstractions.Services.User;
using EatwellApi.Persistence.Context;
using EatwellApi.Persistence.Repositories.User;
using EatwellApi.Persistence.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EatwellApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
                options.EnableSensitiveDataLogging();
            });



            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserReadService, UserReadManager>();
            services.AddScoped<IUserWriteService, UserWriteManager>();
        }
    }
}
