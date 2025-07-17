using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.GetSalesCart
{
    public class GetSalesCartRequestValidator: AbstractValidator<GetSalesCartRequest>
    {
        public GetSalesCartRequestValidator()
        {
            RuleFor(x => x.SalesCartId)
            .NotEmpty()
            .WithMessage("SalesCart ID is required");

        }
    }
}
