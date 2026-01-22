using EatwellApi.Application.Abstractions.Security;
using EatwellApi.Application.Abstractions.Services.EmailService;
using EatwellApi.Application.Utilities.IoC;
using EatwellApi.Infrastructure.Services.EmailService.Sendinblue;
using EatwellApi.Infrastructure.Services.Security.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace EatwellApi.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            ServiceTool.Create(services);


            services.AddScoped<IEmailService, SendinblueService>();
            services.AddScoped<ITokenHelper, JwtHelper>();
        }
    }
}
