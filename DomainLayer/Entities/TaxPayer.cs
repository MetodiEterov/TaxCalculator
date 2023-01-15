using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class TaxPayer
    {
        [Required(ErrorMessage = "The FullName property is required.")]
        [RegularExpression(@"^(?=[a-zA-Z\s]{4,20}$)(?!.*[_.]{2})[^_.].*[^_.]$", ErrorMessage = "Employee name contains invalid characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "The DateOfBirth property is required.")]
        public DateTime DateOfBirth { get; set; }

        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Enter a valid decimal value for gross income!")]
        public decimal GrossIncome { get; set; }

        [Range(10000, 9999999999, ErrorMessage = "A valid 5 to 10 digits number is necessary!")]
        public ulong SSN { get; set; }

        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Enter a valid decimal value for charity spent!")]
        public decimal CharitySpent { get; set; }
    }
}
