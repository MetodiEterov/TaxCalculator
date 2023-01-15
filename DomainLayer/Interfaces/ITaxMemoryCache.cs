using DomainLayer.Entities;

namespace DomainLayer.Interfaces
{
	public interface ITaxCache
	{
		void SetCache(IEnumerable<TaxPayerMng> taxPayers);

		IEnumerable<TaxPayerMng> GetCache();
	}
}
