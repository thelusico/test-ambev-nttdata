using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesCart.CancelSalesCart
{
    public class CancelSalesCartValidator : AbstractValidator<CancelSalesCartRequest>
    {
        public CancelSalesCartValidator()
        {
            RuleFor(x => x.SalesCartId)
            .NotEmpty()
            .WithMessage("SalesCart ID is required");
        }
    }
}
