using AutoMapper;

using ServiceLayer.Estimations;

using DomainLayer.Entities;
using DomainLayer.Interfaces;

using Microsoft.Extensions.Caching.Memory;
using CalculateSalaryAPIs.CommonServices;

namespace UnitTestProject
{
	public class BaseTest
	{
		public IMapper _autoMapper;
		private IMemoryCache _memoryCache;
		public ITaxCache _taxMemoryCache;
		public ICalculateService _calculateService;
		private IFeesManagement _feesManagement;

		public BaseTest()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
			_autoMapper = config.CreateMapper();

			_feesManagement = new FeesManagement();
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            _taxMemoryCache = new TaxCache(_memoryCache);
			_calculateService = new CalculateService(_feesManagement, _autoMapper);
		}
	}
}
