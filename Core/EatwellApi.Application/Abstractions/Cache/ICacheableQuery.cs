using EatwellApi.Application.Parameters;

namespace EatwellApi.Application.Abstractions.Cache
{
    // Sadece cache'lenebilecek query’leri işaretliyoruz.
    public interface ICacheableQuery
    {
        string GetCacheKey()
        {
            string key = GetType().Name;

            // Eğer sınıf PaginationRequest'ten türüyorsa, sayfalama bilgilerini de ekliyoruz
            if (this is PaginationRequest paginationRequest)
                key += $":Page_{paginationRequest.PageNumber}_{paginationRequest.PageSize}";

            return key;
        }
    }
}
