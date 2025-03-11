using CashMinder.Application.Interfaces.RedisCache;
using MediatR;

namespace CashMinder.Application.Behaviours
{
    public class RedisCacheBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisCacheBehaviour(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(request is ICacheableQuery query)
            {
                var cacheKey = query.CacheKey;
                var cacheTime = query.CacheTime;

                var cachedData = await redisCacheService.GetAsync<TResponse>(cacheKey);
                if(cachedData != null)
                    return cachedData;
                
                var response = await next();
                if(response != null)
                    await redisCacheService.SetAsync(cacheKey, response, DateTime.UtcNow.AddMinutes(cacheTime));
                return response;
            }
            return await next();
        }
    }
}