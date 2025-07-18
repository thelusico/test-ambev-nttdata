using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Test data generator for SalesCart and related entities
    /// </summary>
    public static class SalesCartTestData
    {
        private static readonly Faker _faker = new Faker();

        public static SalesCart GenerateValidSalesCart()
        {
            var saleNumber = GenerateValidSaleNumber();
            var customer = GenerateValidCustomerInfo();
            var branch = GenerateValidBranchInfo();
            var items = GenerateValidSalesCartItems(_faker.Random.Int(1, 5));

            return new SalesCart(saleNumber, customer, branch, items);
        }    

        public static string GenerateValidSaleNumber()
        {
            var now = DateTime.UtcNow;
            var datePart = now.ToString("yyyyMMdd");
            var timePart = now.ToString("HHmmss");
            var randomPart = _faker.Random.Int(1000, 9999);

            return $"AMB-{datePart}-{timePart}-{randomPart}";
        }

        public static CustomerInfo GenerateValidCustomerInfo()
        {
            return new CustomerInfo(
                Guid.NewGuid(),
                _faker.Person.UserName,
                _faker.Person.Email
            );
        }

        public static BranchInfo GenerateValidBranchInfo()
        {
            return new BranchInfo(
                Guid.NewGuid(),
                _faker.Company.CompanyName(),
                _faker.Address.FullAddress()
            );
        }

        public static SalesCartItem GenerateValidSalesCartItem()
        {
            return new SalesCartItem(
                Guid.NewGuid(),
                _faker.Commerce.ProductName(),
                _faker.Commerce.Categories(1).First(),
                _faker.Random.Int(1, 10),
                _faker.Random.Decimal(10, 1000),
                _faker.Random.Decimal(0, 50)
            );
        }

        public static List<SalesCartItem> GenerateValidSalesCartItems(int count = 3)
        {
            var items = new List<SalesCartItem>();
            for (int i = 0; i < count; i++)
            {
                items.Add(GenerateValidSalesCartItem());
            }
            return items;
        }

        public static string GenerateInvalidSaleNumber()
        {
            return string.Empty;
        }

        public static CustomerInfo GenerateInvalidCustomerInfo()
        {
            return new CustomerInfo(
                Guid.Empty,
                string.Empty,
                "invalid-email"
            );
        }
        public static BranchInfo GenerateInvalidBranchInfo()
        {
            return new BranchInfo(
                Guid.Empty,
                string.Empty,
                string.Empty
            );
        }

        public static SalesCartItem GenerateInvalidSalesCartItem()
        {
            return new SalesCartItem(
                Guid.Empty,
                string.Empty,
                string.Empty,
                0,
                -10,
                -5);
        }

        public static SalesCart GenerateInvalidSalesCart()
        {
            return new SalesCart(                
                GenerateInvalidSaleNumber(),
                GenerateInvalidCustomerInfo(),
                GenerateInvalidBranchInfo(),
                new List<SalesCartItem> { GenerateInvalidSalesCartItem() }
            );
        }

    }
}
