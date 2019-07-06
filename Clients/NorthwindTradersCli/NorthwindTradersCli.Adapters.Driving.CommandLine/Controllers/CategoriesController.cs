using System;
using System.Linq;
using System.Threading.Tasks;
using NorthwindTradersCli.Adapters.Driving.CommandLine.Services;
using NorthwindTradersCli.Application.Categories;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine.Controllers
{
    public class CategoriesController : ICategoriesController
    {
        private readonly ICategoriesService _categoriesService;
        private readonly ICategoryPrinter _categoryPrinter;

        public CategoriesController(
            ICategoriesService categoriesService,
            ICategoryPrinter categoryPrinter)
        {
            _categoriesService = categoriesService;
            _categoryPrinter = categoryPrinter;
        }

        public async Task Get()
        {
            var categories = (await _categoriesService.GetCategoriesAsync())?.ToList();

            if (categories == null || !categories.Any())
            {
                Console.WriteLine("Categories not found");
                return;
            }

            foreach (var category in categories)
            {
                _categoryPrinter.PrintCategory(category);
            }
        }

        public async Task Get(int id)
        {
            var category = await _categoriesService.GetCategoryAsync(id);

            if (category == null)
            {
                Console.WriteLine($"Category with id {id} not found");
                return;
            }

            _categoryPrinter.PrintCategory(category);
        }
    }
}
