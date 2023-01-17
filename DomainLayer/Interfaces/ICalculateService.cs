using DomainLayer.DTOs;

namespace DomainLayer.Interfaces
{
    public interface ICalculateService
	{
		TaxPayerMng CalculatePayerTaxes(TaxPayerMng emp);
	}
}
 