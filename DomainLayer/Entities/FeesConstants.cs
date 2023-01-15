namespace DomainLayer.Entities
{
	public abstract class FeesConstants
	{
		public virtual decimal TaxFreeAmount { get; set; } = 1000m;

		public virtual decimal MaxSocialFeeAmount { get; set; } = 2000m;

		public virtual decimal SSN { get; set; } = 0.1m;

		public virtual decimal CharitySpent { get; set; } = 0.1m;

		public virtual decimal SocialContributions { get; set; } = 0.15m;
	}
}
