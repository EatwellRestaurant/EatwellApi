using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Abstractions.Repositories.Employee;
using EatwellApi.Application.Abstractions.Repositories.HeadOffice;
using EatwellApi.Application.Abstractions.Repositories.PageContent;
using EatwellApi.Application.Abstractions.Repositories.Product;
using EatwellApi.Application.Abstractions.Repositories.Reservation;
using EatwellApi.Application.Abstractions.Services.Employee;
using EatwellApi.Application.Abstractions.Services.Reservation;
using EatwellApi.Application.Abstractions.Services.User;
using EatwellApi.Persistence.Context;
using EatwellApi.Persistence.Repositories;
using EatwellApi.Persistence.Repositories.Employee;
using EatwellApi.Persistence.Repositories.HeadOffice;
using EatwellApi.Persistence.Repositories.PageContent;
using EatwellApi.Persistence.Repositories.Product;
using EatwellApi.Persistence.Repositories.Reservation;
using EatwellApi.Persistence.Repositories.User;
using EatwellApi.Persistence.Services.Employee;
using EatwellApi.Persistence.Services.Reservation;
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

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();

            services.AddScoped<IPageContentReadRepository, PageContentReadRepository>();

            services.AddScoped<IHeadOfficeReadRepository, HeadOfficeReadRepository>();

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationReadRepository, ReservationReadRepository>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserReadService, UserReadManager>();
            services.AddScoped<IUserWriteService, UserWriteManager>();
        }
    }
}
