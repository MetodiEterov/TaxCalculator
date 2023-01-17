namespace DomainLayer.DTOs
{
    public class TaxPayerMng
    {
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal TempIncome { get; set; }

        public decimal GrossIncome { get; set; }

        public decimal IncomeTax { get; set; }

        public decimal SocialTax { get; set; }

        public decimal TotalTax { get; set; }

        public decimal NetIncome { get; set; }

        public decimal CharitySpent { get; set; }

        public ulong SSN { get; set; }
    }
}
