using EatwellApi.Application.Constants.Cache;

namespace EatwellApi.Application.Abstractions.Cache
{
    // Sadece cache'lenebilecek query’leri işaretliyoruz.
    public interface ICacheableQuery
    {
        int CacheDuration => CacheDefaults.DefaultDuration;
    }
}
