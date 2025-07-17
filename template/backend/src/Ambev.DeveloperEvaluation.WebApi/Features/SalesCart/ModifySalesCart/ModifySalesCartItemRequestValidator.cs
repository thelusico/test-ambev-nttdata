using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.ModifySalesCart
{
    public class ModifySalesCartItemRequestValidator: AbstractValidator<ModifySalesCartItemRequest>
    {
        public ModifySalesCartItemRequestValidator()
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
