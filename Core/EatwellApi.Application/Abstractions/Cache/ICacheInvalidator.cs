namespace EatwellApi.Application.Abstractions.Cache
{
    // Cache'i temizlenmesi gereken command'lar bu interface ile işaretlenecek.
    public interface ICacheInvalidator
    {
        IEnumerable<string> CacheKeysToInvalidate { get; }
    }
}
