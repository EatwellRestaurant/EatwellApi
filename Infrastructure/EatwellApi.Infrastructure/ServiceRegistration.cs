using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Abstractions.Security;
using EatwellApi.Application.Abstractions.Services.EmailService;
using EatwellApi.Application.Utilities.IoC;
using EatwellApi.Infrastructure.Services.Cache.RedisCache;
using EatwellApi.Infrastructure.Services.EmailService.Sendinblue;
using EatwellApi.Infrastructure.Services.Security.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace EatwellApi.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            ServiceTool.Create(services);

            services.Configure<RedisCacheSettings>(configuration.GetSection(nameof(RedisCacheSettings)));

            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                RedisCacheSettings settings = sp.GetRequiredService<IOptions<RedisCacheSettings>>().Value;

                // Parse() hem deployment hem de production ortamlarındaki
                // farklı formatları doğru okur. Ortama göre appsettings'ten gelir.
                ConfigurationOptions options = ConfigurationOptions.Parse(settings.ConnectionString);


                // Redis'e ilk bağlantı kurulamazsa uygulamanın crash olmamasını (yani uygulamanın durdurulmamasını) sağlar.
                options.AbortOnConnectFail = false;


                // TCP keep-alive süresi (saniye).
                // Belirtilen süre boyunca veri gitmezse bağlantının canlı tutulmasını sağlar.
                // Yani Redis ile API arasında hiç veri alışverişi olmasa bile
                // 60 saniyede bir küçük bir “ben buradayım” sinyali gönderilir.
                options.KeepAlive = 60;


                // İlk bağlantı başarısız olursa kaç kez yeniden deneneceğini belirtir.
                options.ConnectRetry = 3;


                // Redis'e bağlanırken beklenecek maksimum süre (ms).
                options.ConnectTimeout = 15000;


                // Senkron Redis komutları için maksimum bekleme süresi (ms).
                // Bu süre aşılırsa timeout exception fırlatılır.
                options.SyncTimeout = 15000;

                
                // Asenkron Redis komutları için maksimum bekleme süresi (ms).
                options.AsyncTimeout = 15000;
                
                
                // Uygulama deployment ortamda ayağa kaldırılırsa cache'leme işlemi
                // localhost'ta yapılırken production ortamda Upstash kullanılarak yapılır.

                return ConnectionMultiplexer.Connect(options);
            });

            services.AddScoped<IEmailService, SendinblueService>();
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddSingleton<ICacheService, RedisCacheService>();
        }
    }
}
