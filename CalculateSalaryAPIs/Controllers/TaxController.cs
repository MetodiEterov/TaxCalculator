using AutoMapper;

using DomainLayer.DTOs;
using DomainLayer.Entities;
using DomainLayer.Interfaces;

using Microsoft.AspNetCore.Mvc;
using CalculateSalaryAPIs.CommonServices;

namespace CalculateSalaryAPIs.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class TaxController : ControllerBase
	{
		#region Initialization

		private readonly ITaxCache _taxMemoryCache;
		private readonly IMapper _automapper;
		private readonly ICalculateService _calculateService;
		private readonly IEnumerable<TaxPayerMng> _taxPayerCache;

		public TaxController(ICalculateService calculateService, ITaxCache testChache, IMapper automapper)
		{
			_calculateService = calculateService;
			_automapper = automapper;
			_taxMemoryCache = testChache;

			_taxPayerCache = _taxMemoryCache.GetCache() ?? new List<TaxPayerMng>();
		}

		#endregion

		#region POST methods

		[HttpPost]
		[ServiceFilter(typeof(ModelValidationAttribute))]
		public IActionResult Calculate([FromBody] TaxPayer salary)
		{
			TaxPayerMng calculated = _calculateService.CalculatePayerTaxes(_automapper.Map<TaxPayerMng>(salary));
			PutToCache(calculated);

			return Ok(_automapper.Map<TaxPayerDTO>(calculated));
		}

		#endregion

		#region Implementations

		private void PutToCache(TaxPayerMng calculated)
		{
			((List<TaxPayerMng>)_taxPayerCache).Add(calculated);
			_taxMemoryCache.SetCache(_taxPayerCache);
		}

		#endregion
	}
}
