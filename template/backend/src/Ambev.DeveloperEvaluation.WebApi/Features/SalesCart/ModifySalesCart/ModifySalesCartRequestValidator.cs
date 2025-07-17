using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.ModifySalesCart
{
    public class ModifySalesCartRequestValidator : AbstractValidator<ModifySalesCartRequest>
    {
        public ModifySalesCartRequestValidator()
        {
            RuleFor(x => x.SalesCartId)
                .NotEmpty()
                .WithMessage("Sales Cart ID is required");

            RuleFor(x => x.Customer)
                .NotEmpty()
                .When(x => x.Customer.HasValue)
                .WithMessage("Customer ID cannot be empty when provided");

            RuleFor(x => x.Branch)
                .NotEmpty()
                .When(x => x.Branch.HasValue)
                .WithMessage("Branch ID cannot be empty when provided");

            RuleFor(x => x.Items)
                .NotNull()
                .WithMessage("Items list cannot be null")
                .NotEmpty()
                .WithMessage("At least one item is required");

            RuleForEach(x => x.Items)
                .SetValidator(new ModifySalesCartItemRequestValidator());
        }


    }
}
