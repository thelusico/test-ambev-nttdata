using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CreateSalesCart
{
    public class CreateSalesCartItemRequestValidator : AbstractValidator<CreateSalesCartItemRequest>
    {
        public CreateSalesCartItemRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Product ID is required");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero")
                .LessThanOrEqualTo(20)
                .WithMessage("Maximum quantity per product is 20 items");
        }
    }
}
