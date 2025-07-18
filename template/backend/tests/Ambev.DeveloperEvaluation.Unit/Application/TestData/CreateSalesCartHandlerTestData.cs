using Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart;
using Ambev.DeveloperEvaluation.Application.SalesCart.CreateSalesCart.Results;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class CreateSalesCartHandlerTestData
    {

        private static readonly Faker<CreateSalesCartCommand> createSalesCartCommandFaker = new Faker<CreateSalesCartCommand>()
         .RuleFor(c => c.Customer, f => Guid.NewGuid())
         .RuleFor(c => c.Branch, f => Guid.NewGuid())
         .RuleFor(c => c.Items, f => createSalesCartItemCommandFaker.Generate(f.Random.Int(1, 5)));

        private static readonly Faker<CreateSalesCartItemCommand> createSalesCartItemCommandFaker = new Faker<CreateSalesCartItemCommand>()
         .RuleFor(i => i.ProductId, f => Guid.NewGuid())
         .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20));

        private static readonly Faker<User> userFaker = new Faker<User>()
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.Username, f => f.Internet.UserName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Phone, f => $"+55{f.Random.Number(11, 99)}{f.Random.Number(100000000, 999999999)}")
            .RuleFor(u => u.Status, f => f.PickRandom<UserStatus>())
            .RuleFor(u => u.Role, f => f.PickRandom<UserRole>());

        private static readonly Faker<BranchInfo> branchFaker = new Faker<BranchInfo>()
            .RuleFor(b => b.BranchId, f => Guid.NewGuid())
            .RuleFor(b => b.Name, f => f.Company.CompanyName())
            .RuleFor(b => b.Location, f => f.Address.FullAddress());

        private static readonly Faker<Product> productFaker = new Faker<Product>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.Title, f => f.Commerce.ProductName())
            .RuleFor(p => p.Category, f => f.PickRandom<ProductCategory>())
            .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000))
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription());

        private static readonly Faker<CreateSalesCartResult> createSalesCartResultFaker = new Faker<CreateSalesCartResult>()
            .RuleFor(r => r.Id, f => Guid.NewGuid())
            .RuleFor(r => r.SaleNumber, f => $"SALE-{DateTime.UtcNow:yyyyMMdd}-{f.Random.Int(1000, 9999)}")
            .RuleFor(r => r.Customer, f => Guid.NewGuid())
            .RuleFor(r => r.Branch, f => Guid.NewGuid())
            .RuleFor(r => r.TotalAmount, f => f.Random.Decimal(10, 5000))
            .RuleFor(r => r.CreatedAt, f => DateTime.UtcNow);

        public static CreateSalesCartCommand GenerateValidCommand()
        {
            return createSalesCartCommandFaker.Generate();
        }

        public static CreateSalesCartCommand GenerateInvalidCommand()
        {
            return new CreateSalesCartCommand
            {
                Customer = Guid.Empty, // Invalid customer ID
                Branch = Guid.Empty,   // Invalid branch ID
                Items = new List<CreateSalesCartItemCommand>() // Empty items list
            };
        }

        public static User GenerateValidUser()
        {
            return userFaker.Generate();
        }

        public static User GenerateValidUser(Guid userId)
        {
            var user = userFaker.Generate();
            user.Id = userId;
            return user;
        }

        public static BranchInfo GenerateValidBranch()
        {
            return branchFaker.Generate();
        }

        public static BranchInfo GenerateValidBranch(Guid branchId)
        {
            var branch = branchFaker.Generate();
            branch.BranchId = branchId;
            return branch;
        }

        public static Product GenerateValidProduct()
        {
            return productFaker.Generate();
        }

        public static Product GenerateValidProduct(Guid productId)
        {
            var product = productFaker.Generate();
            product.Id = productId;
            return product;
        }

        public static List<Product> GenerateValidProducts(int count = 3)
        {
            return productFaker.Generate(count);
        }

        public static CreateSalesCartResult GenerateValidResult()
        {
            return createSalesCartResultFaker.Generate();
        }

        public static CreateSalesCartResult GenerateValidResult(Guid salesCartId)
        {
            var result = createSalesCartResultFaker.Generate();
            result.Id = salesCartId;
            return result;
        }

        public static SalesCart GenerateValidSalesCart()
        {
            var faker = new Faker();

            var customerInfo = new CustomerInfo(
                Guid.NewGuid(),
                faker.Internet.UserName(),
                faker.Internet.Email()
            );

            var branchInfo = new BranchInfo(
                Guid.NewGuid(),
                faker.Company.CompanyName(),
                faker.Address.FullAddress()
            );

            var items = new List<SalesCartItem>
            {
                new SalesCartItem(
                    Guid.NewGuid(),
                    faker.Commerce.ProductName(),
                    faker.PickRandom<ProductCategory>().ToString(),
                    faker.Random.Int(1, 10),
                    faker.Random.Decimal(10, 500),
                    faker.Random.Decimal(0, 50)
                )
            };

            var saleNumber = $"AMB-{DateTime.UtcNow:yyyyMMdd}-{faker.Random.Int(1000, 9999)}";

            var salesCart = new SalesCart(saleNumber, customerInfo, branchInfo, items);
            salesCart.Id = Guid.NewGuid();
            salesCart.TotalAmount = faker.Random.Decimal(100, 2000);

            return salesCart;
        }

        public static string GenerateUniqueSaleNumber()
        {
            var faker = new Faker();
            return $"SALE-{DateTime.UtcNow:yyyyMMdd}-{faker.Random.Int(1000, 9999)}";
        }
    }
}
