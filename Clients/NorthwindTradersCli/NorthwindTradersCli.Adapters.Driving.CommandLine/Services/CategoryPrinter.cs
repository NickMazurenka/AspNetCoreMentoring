using System;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine.Services
{
    public class CategoryPrinter : ICategoryPrinter
    {
        public void PrintCategory(Category category)
        {
            Console.WriteLine($"Category {category.CategoryId}");
            Console.WriteLine($"> CategoryName: {category.CategoryName}");
            Console.WriteLine($"> Description: {category.Description}");
        }
    }
}
