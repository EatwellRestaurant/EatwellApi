using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Wrappers;
using MediatR;

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
            if (request is ICacheableQuery cacheableQuery)
            {
                string cacheKey = typeof(TRequest).Name;

                TResponse? cachedData = await _cacheService
                    .GetAsync<TResponse>(cacheKey);

                if (cachedData != null)
                    return cachedData;


                TResponse? response = await next();


                if (response != null)
                    await _cacheService
                        .SetAsync(
                            cacheKey, 
                            response,
                            TimeSpan.FromMinutes(cacheableQuery.CacheDuration)
                        );


                return response;
            }

            return await next();
        }
    }
}
