using System;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine.Services
{
    public class ProductPrinter : IProductPrinter
    {
        public void PrintProduct(Product product)
        {
            Console.WriteLine($"Product {product.ProductId}");
            Console.WriteLine($"> ProductName: {product.ProductName}");
            Console.WriteLine($"> QuantityPerUnit: {product.QuantityPerUnit}");
            Console.WriteLine($"> UnitPrice: {product.UnitPrice}");
            Console.WriteLine($"> UnitsInStock: {product.UnitsInStock}");
            Console.WriteLine($"> Discontinued: {product.Discontinued}");
        }
    }
}
