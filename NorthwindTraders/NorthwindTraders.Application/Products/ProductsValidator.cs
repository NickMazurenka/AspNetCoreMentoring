using FluentValidation;
using NorthwindTraders.Domain.Products;

namespace NorthwindTraders.Application.Products
{
    public class ProductsValidator : AbstractValidator<Product>
    {
        public ProductsValidator()
        {
            RuleFor(e => e.ProductId).NotNull();
            RuleFor(e => e.ProductName).NotEmpty().MaximumLength(40);
            RuleFor(e => e.QuantityPerUnit).MaximumLength(20);
        }
    }
}
