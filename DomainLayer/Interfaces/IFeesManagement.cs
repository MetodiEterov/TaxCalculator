namespace DomainLayer.Interfaces
{
	public interface IFeesManagement
	{
		decimal GetBaseTaxFromAmount(decimal amount);

		decimal GetSocialContributionsFromAmount(decimal amount);

		decimal GetCharitySpentFromAmount(decimal amount);
	}
}
