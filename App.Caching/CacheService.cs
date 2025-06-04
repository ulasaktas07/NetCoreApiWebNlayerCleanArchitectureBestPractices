﻿using App.Aplication.Contract.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace App.Caching
{
	public class CacheService(IMemoryCache memoryCache) : ICacheService
	{
		public Task AddAsync<T>(string cacheKey, T value, TimeSpan timeSpan)
		{
			var cacheOptions = new MemoryCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = timeSpan
			};
			memoryCache.Set(cacheKey, value, cacheOptions);
			return Task.CompletedTask;
		}

		public Task<T?> GetAsync<T>(string cacheKey)
		{
			return memoryCache.TryGetValue(cacheKey, out T cacheItem) ? Task.FromResult(cacheItem) : Task.FromResult(default(T));
		}

		public Task RemoveAsync(string cacheKey)
		{
			memoryCache.Remove(cacheKey);
			return Task.CompletedTask;
		}
	}
}
