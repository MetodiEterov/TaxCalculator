using DomainLayer.DTOs;

using Microsoft.AspNetCore.Mvc;
using CalculateSalaryAPIs.Controllers;

namespace UnitTestProject
{
    [TestClass]
	public class CalculationTest : BaseTest
	{
		private TaxController _objUnderTest;

		public CalculationTest()
		{
			_objUnderTest = new TaxController(_calculateService, _taxMemoryCache, _autoMapper);
		}

		#region Test methods

		[TestMethod]
		public void Estimate_George_Taxes()
		{
			// Arange
			decimal expectedCharitySpent = 0m;
			decimal expectedNetIncome = 980;
			TaxPayer testGeorge = new()
			{
				CharitySpent = 0,
				DateOfBirth = DateTime.Now.AddYears(-20),
				FullName = "George Lastname",
				GrossIncome = 980m,
				SSN = 11111
			};

			// Act
			var request = _objUnderTest.Calculate(testGeorge);
			var converted = request as IActionResult;

			// Assert
			Assert.IsNotNull(_objUnderTest);
			Assert.IsTrue(request is OkObjectResult);
			Assert.IsNotNull(request);
			Assert.AreEqual(((ObjectResult)converted).StatusCode, 200);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).NetIncome, expectedNetIncome);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).CharitySpent, expectedCharitySpent);
		}

		[TestMethod]
		public void Estimate_Irina_Taxes()
		{
			// Arange
			decimal expectedCharitySpent = 0m;
			decimal expectedGrossIncome = 3400m;
			decimal expectedIncomeTax = 240m;
			decimal expectedSocialTaxes = 300m;
			decimal expectedTotalTaxes = 540m;
			decimal expectedNetIncome = 2860m;
			TaxPayer testIrina = new()
			{
				CharitySpent = 0,
				DateOfBirth = DateTime.Now.AddYears(-30),
				FullName = "Irina Lastname",
				GrossIncome = 3400,
				SSN = 11112
			};

			// Act
			var request = _objUnderTest.Calculate(testIrina);
			var converted = request as IActionResult;

			// Assert
			Assert.IsNotNull(_objUnderTest);
			Assert.IsTrue(request is OkObjectResult);
			Assert.IsNotNull(request);
			Assert.AreEqual(((ObjectResult)converted).StatusCode, 200);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).NetIncome, expectedNetIncome);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).IncomeTax, expectedIncomeTax);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).SocialTax, expectedSocialTaxes);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).TotalTax, expectedTotalTaxes);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).GrossIncome, expectedGrossIncome);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).CharitySpent, expectedCharitySpent);
		}

		[TestMethod]
		public void Estimate_Mick_Taxes()
		{
			// Arange
			decimal expectedCharitySpent = 150m;
			decimal expectedGrossIncome = 2500m;
			decimal expectedIncomeTax = 135m;
			decimal expectedSocialTaxes = 202.5m;
			decimal expectedTotalTaxes = 337.5m;
			decimal expectedNetIncome = 2162.5m;
			TaxPayer testMick = new()
			{
				CharitySpent = 150,
				DateOfBirth = DateTime.Now.AddYears(-25),
				FullName = "Mick Lastname",
				GrossIncome = 2500,
				SSN = 11112
			};

			// Act
			var request = _objUnderTest.Calculate(testMick);
			var converted = request as IActionResult;

			// Assert
			Assert.IsNotNull(_objUnderTest);
			Assert.IsTrue(request is OkObjectResult);
			Assert.IsNotNull(request);
			Assert.AreEqual(((ObjectResult)converted).StatusCode, 200);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).NetIncome, expectedNetIncome);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).IncomeTax, expectedIncomeTax);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).SocialTax, expectedSocialTaxes);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).TotalTax, expectedTotalTaxes);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).GrossIncome, expectedGrossIncome);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).CharitySpent, expectedCharitySpent);
		}

		[TestMethod]
		public void Estimate_Bill_Taxes()
		{
			// Arange
			decimal expectedCharitySpent = 520m;
			decimal expectedGrossIncome = 3600m;
			decimal expectedIncomeTax = 224m;
			decimal expectedSocialTaxes = 300m;
			decimal expectedTotalTaxes = 524m;
			decimal expectedNetIncome = 3076m;
			TaxPayer testBill = new()
			{
				CharitySpent = 520,
				DateOfBirth = DateTime.Now.AddYears(-25),
				FullName = "Bill Lastname",
				GrossIncome = 3600,
				SSN = 11112
			};

			// Act
			var request = _objUnderTest.Calculate(testBill);
			var converted = request as IActionResult;

			// Assert
			Assert.IsNotNull(_objUnderTest);
			Assert.IsTrue(request is OkObjectResult);
			Assert.IsNotNull(request);
			Assert.AreEqual(((ObjectResult)converted).StatusCode, 200);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).NetIncome, expectedNetIncome);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).IncomeTax, expectedIncomeTax);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).SocialTax, expectedSocialTaxes);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).TotalTax, expectedTotalTaxes);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).GrossIncome, expectedGrossIncome);
			Assert.AreEqual((((ObjectResult)converted).Value as TaxPayerDTO).CharitySpent, expectedCharitySpent);
		}

		#endregion
	}
}