using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Interfaces;

namespace ServiceLayer.Estimations
{
    public class CalculateService : FeesConstants, ICalculateService
	{
		private readonly IMapper _automapper;
		private readonly IFeesManagement _feesManagement;
		public CalculateService(IFeesManagement feesManagement, IMapper automapper)
		{
			_feesManagement = feesManagement;
			_automapper = automapper;
		}

		public TaxPayerMng CalculatePayerTaxes(TaxPayerMng emp)
		{
			CheckSalaryAmount(emp);
			switch (emp.TempIncome)
			{
				case var amount when amount > TaxFreeAmount:
					emp.SocialTax = _feesManagement.GetSocialContributionsFromAmount(emp.TempIncome);
					emp.IncomeTax = _feesManagement.GetBaseTaxFromAmount(emp.TempIncome);
					emp.TotalTax = emp.SocialTax + emp.IncomeTax;
					break;
			}

			return _automapper.Map<TaxPayerMng>(emp);
		}

		private void CheckSalaryAmount(TaxPayerMng emp) => emp.TempIncome = emp.CharitySpent > _feesManagement.GetCharitySpentFromAmount(emp.GrossIncome)
				? emp.GrossIncome - _feesManagement.GetCharitySpentFromAmount(emp.GrossIncome) - TaxFreeAmount
				: emp.GrossIncome - emp.CharitySpent - TaxFreeAmount;
	}
}
