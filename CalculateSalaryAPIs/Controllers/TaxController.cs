using AutoMapper;

using DomainLayer.DTOs;
using DomainLayer.Entities;
using DomainLayer.Interfaces;

using Microsoft.AspNetCore.Mvc;
using TestTask.CommonServices;

namespace TestTask.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaxController : ControllerBase
	{
		#region Initialization

		private readonly ITaxCache _taxMemoryCache;
		private readonly IMapper _automapper;
		private readonly ICalculateService _calculateService;
		private IEnumerable<TaxPayerMng> _taxPayerCache;

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
			TaxPayerMng calulated = _calculateService.CalculatePayerTaxes(_automapper.Map<TaxPayerMng>(salary));
			PutToCache(calulated);

			return Ok(_automapper.Map<TaxPayerDTO>(calulated));
		}

		#endregion

		#region Implementations

		private void PutToCache(TaxPayerMng calulated)
		{
			((List<TaxPayerMng>)_taxPayerCache).Add(calulated);
			_taxMemoryCache.SetCache(_taxPayerCache);
		}

		#endregion
	}
}
