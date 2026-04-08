using EatwellApi.Application.Abstractions.Cache;
using MediatR;

namespace EatwellApi.Application.Behaviors.Cache
{
    public class CacheInvalidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        readonly ICacheService _cache;

        public CacheInvalidationBehavior(ICacheService cache)
            => _cache = cache;


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse? response = await next();


            // Başarıyla tamamlandıysa cache'(ler)i temizliyoruz.
            if (request is ICacheInvalidator invalidator)
                await _cache.RemoveRangeAsync(invalidator.CacheKeysToInvalidate.ToArray());


            return response;
        }
    }
}
