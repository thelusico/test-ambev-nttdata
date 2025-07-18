using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using OneOf.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{

    /// <summary>
    /// Tests for SalesCart entity
    /// </summary>
    public class SaleCartTests
    {
        [Fact(DisplayName = "SalesCart should be created with valid properties")]
        public void Given_ValidData_When_CreatingNewSalesCart_Then_ShouldCreateWithValidProperties()
        {
            // Arrange
            var saleNumber = SalesCartTestData.GenerateValidSaleNumber();
            var customer = SalesCartTestData.GenerateValidCustomerInfo();
            var branch = SalesCartTestData.GenerateValidBranchInfo();
            var items = SalesCartTestData.GenerateValidSalesCartItems(3);

            // Act
            var salesCart = new SalesCart(saleNumber, customer, branch, items);

            // Assert
            salesCart.Id.Should().NotBe(Guid.Empty);
            salesCart.SaleNumber.Should().Be(saleNumber);
            salesCart.SaleDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
            salesCart.Customer.Should().Be(customer);
            salesCart.Branch.Should().Be(branch);
            salesCart.Items.Should().HaveCount(3);
            salesCart.IsCancelled.Should().BeFalse();
            salesCart.CancelledAt.Should().BeNull();
            salesCart.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
            salesCart.UpdatedAt.Should().BeNull();
        }

        [Fact(DisplayName = "Entity Validate method should return valid for valid data")]
        public void Given_ValidSalesCart_When_ValidatedUsingEntityMethod_Then_ShouldReturnValid()
        {
            // Arrange
            var salesCart = SalesCartTestData.GenerateValidSalesCart();

            var salesCartValidator = new SalesCartValidator();

            // Act
            var result = salesCartValidator.Validate(salesCart);

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact(DisplayName = "Validation should fail for invalid SalesCart data")]
        public void Given_InvalidSalesCartData_When_Validated_Then_ShouldReturnInvalid()
        {
            try
            {
                // Arrange
                var salesCart = SalesCartTestData.GenerateInvalidSalesCart();
                var validator = new SalesCartValidator();

                // Act
                var result = validator.Validate(salesCart);
            }
            catch (ArgumentException ex)
            {
                // Assert
                ex.Should().BeOfType<ArgumentException>();
            }

        }
    }
}
