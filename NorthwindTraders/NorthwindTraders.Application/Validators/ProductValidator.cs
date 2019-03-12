using FluentValidation;
using NorthwindTraders.Domain.Entities;

namespace NorthwindTraders.Application.Validators
{
    public class ProductValidator : AbstractValidator<Products>
    {
        public ProductValidator()
        {
            RuleFor(e => e.ProductId).NotNull();
            RuleFor(e => e.ProductName).NotEmpty().MaximumLength(40);
            RuleFor(e => e.QuantityPerUnit).MaximumLength(20);
        }
    }
}
