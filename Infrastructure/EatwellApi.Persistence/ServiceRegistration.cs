using EatwellApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EatwellApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/KayraExport.Api"));
            configurationManager.AddJsonFile("appsettings.json");


            services.AddDbContext<RestaurantContext>(options =>
            {
                options.UseSqlServer(configurationManager.GetConnectionString("SqlConnection"));
                options.EnableSensitiveDataLogging();
            });

        }
    }
}
