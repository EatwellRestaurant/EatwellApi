using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Constants.Cache;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using MediatR;
using System.Reflection;

namespace EatwellApi.Application.Behaviors.Cache
{
    public class RedisCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Response
    {
        readonly ICacheService _cacheService;
        public RedisCacheBehavior(ICacheService cacheService)
            => _cacheService = cacheService;



        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Sadece query’leri cacheliyoruz.
            if (request is ICacheableQuery)
            {
                string cacheKey = typeof(TRequest).Name;

                if (request is PaginationRequest paginationRequest)
                    cacheKey += $"_{paginationRequest.PageNumber}_{paginationRequest.PageSize}";


                TResponse? cachedData = await _cacheService
                    .GetAsync<TResponse>(cacheKey);

                if (cachedData != null)
                    return cachedData;


                TResponse? response = await next();


                // Request sınıfındaki [Cache] attribute'larını buluyoruz.
                var cacheAttributes = request.GetType()
                    .GetCustomAttributes<CacheAttribute>()
                    .FirstOrDefault();


                if (response != null)
                    await _cacheService
                        .SetAsync(
                            cacheKey,
                            response,
                            TimeSpan.FromMinutes(cacheAttributes?.Duration ?? CacheDefaults.DefaultDuration)
                        );


                return response;
            }

            return await next();
        }
    }
}
