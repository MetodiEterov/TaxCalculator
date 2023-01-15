using DomainLayer.Entities;
using DomainLayer.Interfaces;

using Microsoft.Extensions.Caching.Memory;

namespace TestTask.CommonServices
{
	public class TaxCache : ITaxCache
	{
		private MemoryCacheEntryOptions _cacheExpirationOptions;
		private const int _defaultCacheExpirationTime = 30;
		private const string _keyEntry = "TaxPayers";
		private IMemoryCache _memoryCache;
		public TaxCache(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public void SetCache(IEnumerable<TaxPayerMng> taxPayers)
		{
			if (taxPayers != null && taxPayers.Any())
			{
				_cacheExpirationOptions = new MemoryCacheEntryOptions
				{
					AbsoluteExpiration = DateTime.Now.AddMinutes(_defaultCacheExpirationTime),
					Priority = CacheItemPriority.Normal
				};

				_memoryCache.Set(_keyEntry, taxPayers, _cacheExpirationOptions);
			}
		} 

		public IEnumerable<TaxPayerMng> GetCache()
		{
			if (_memoryCache != null && _memoryCache.TryGetValue(_keyEntry, out IEnumerable<TaxPayerMng> taxPayers)) return taxPayers;
			
			return null;
		}
	}

	
}
