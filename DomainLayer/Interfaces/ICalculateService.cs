using DomainLayer.Entities;

namespace DomainLayer.Interfaces
{
    public interface ICalculateService
	{
		TaxPayerMng CalculatePayerTaxes(TaxPayerMng emp);
	}
}
 