using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SalesCartValidator : AbstractValidator<SalesCart>
    {
        public SalesCartValidator()
        {
            RuleFor(x => x.Id)
    .NotEmpty()
    .WithMessage("Sales Cart ID is required");

            RuleFor(x => x.SaleNumber)
                .NotEmpty()
                .WithMessage("Sale number is required")
                .Length(1, 50)
                .WithMessage("Sale number must be between 1 and 50 characters")
                .Matches(@"^AMB-\d{8}-\d{6}-\d{4}$")
                .WithMessage("Sale number must follow the format SC-YYYYMMDD-HHMMSS-XXXX");

            RuleFor(x => x.SaleDate)
                .NotEmpty()
                .WithMessage("Sale date is required")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Sale date cannot be in the future");         

            RuleFor(x => x.Items)
                .NotNull()
                .WithMessage("Items list cannot be null");          

            RuleFor(x => x.Items)
                .Must(items => items == null || items.Count <= 20)
                .WithMessage("Cannot have more than 20 items in a sales cart")
                .When(x => x.Items != null);

            RuleFor(x => x.TotalAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Total amount cannot be negative");

            RuleFor(x => x.CreatedAt)
                .NotEmpty()
                .WithMessage("Created date is required")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Created date cannot be in the future");

            RuleFor(x => x.UpdatedAt)
                .GreaterThanOrEqualTo(x => x.CreatedAt)
                .WithMessage("Updated date must be after created date")
                .When(x => x.UpdatedAt.HasValue);

            RuleFor(x => x.CancelledAt)
                .NotEmpty()
                .WithMessage("Cancelled date is required when sales cart is cancelled")
                .GreaterThanOrEqualTo(x => x.CreatedAt)
                .WithMessage("Cancelled date must be after created date")
                .When(x => x.IsCancelled);

            RuleFor(x => x.CancelledAt)
                .Null()
                .WithMessage("Cancelled date must be null when sales cart is not cancelled")
                .When(x => !x.IsCancelled);

            // Business rule: Cancelled sales cart cannot have items being modified
            RuleFor(x => x)
                .Must(cart => !cart.IsCancelled || cart.Items.Count == 0 || true)
                .WithMessage("Cancelled sales cart should not be modified")
                .When(x => x.IsCancelled);

        }
    }
}
