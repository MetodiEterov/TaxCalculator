using DomainLayer.Interfaces;

namespace DomainLayer.Entities
{
	public class FeesManagement : FeesConstants, IFeesManagement
	{
		public decimal GetBaseTaxFromAmount(decimal amount) => amount * SSN;

		public decimal GetSocialContributionsFromAmount(decimal amount) => (amount <= MaxSocialFeeAmount)
			? amount * SocialContributions : MaxSocialFeeAmount * SocialContributions;

		public decimal GetCharitySpentFromAmount(decimal amount) => amount * CharitySpent;
	}
}
