using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CreateSalesCart
{
    public class CreateSalesCartRequestValidator : AbstractValidator<CreateSalesCartRequest>
    {
        public CreateSalesCartRequestValidator()
        {  
            RuleFor(x => x.Customer)
                .NotEmpty()
                .NotEqual(Guid.Empty)
                .NotNull()
                .WithMessage("Customer ID is required");

            RuleFor(x => x.Branch)
                .NotEmpty()
                .NotEqual(Guid.Empty)
                .NotNull()
                .WithMessage("Branch ID is required");
      
            RuleFor(x => x.Items)
                .NotNull()
                .WithMessage("Items list cannot be null")
                .NotEmpty()
                .WithMessage("At least one item is required");

            RuleForEach(x => x.Items)
                .SetValidator(new CreateSalesCartItemRequestValidator());
        }
    }
}
