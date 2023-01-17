using AutoMapper;

using DomainLayer.DTOs;
using DomainLayer.Entities;

namespace TestTask.CommonServices
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<TaxPayerMng, TaxPayerDTO>();
			CreateMap<TaxPayer, TaxPayerMng>();
			CreateMap<TaxPayerMng, TaxPayerMng>()
				.ForMember(x => x.NetIncome, options => options
					.MapFrom(y => (y.TotalTax == 0) ? (y.GrossIncome - y.CharitySpent) : (y.GrossIncome - y.TotalTax)))
				.ForMember(x => x.TotalTax, options => options.MapFrom(y => (y.TotalTax == 0) ? 0 : y.TotalTax))
				.ForMember(x => x.IncomeTax, options => options.MapFrom(y => (y.TotalTax == 0) ? 0 : y.IncomeTax))
				.ForMember(x => x.GrossIncome, options => options.MapFrom(y => y.GrossIncome));
		}
	}
}
