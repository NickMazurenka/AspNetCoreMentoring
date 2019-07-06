using System;
using System.Linq;
using System.Threading.Tasks;
using NorthwindTradersCli.Adapters.Driving.CommandLine.Services;
using NorthwindTradersCli.Application.Products;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine.Controllers
{
    public class ProductsController : IProductsController
    {
        private readonly IProductsService _productsService;
        private readonly IProductPrinter _productPrinter;

        public ProductsController(
            IProductsService productsService,
            IProductPrinter productPrinter)
        {
            _productsService = productsService;
            _productPrinter = productPrinter;
        }

        public async Task Get()
        {
            var products = (await _productsService.GetProductsAsync())?.ToList();

            if (products == null || !products.Any())
            {
                Console.WriteLine("Products not found");
                return;
            }

            foreach (var product in products)
            {
                _productPrinter.PrintProduct(product);
            }
        }

        public async Task Get(int id)
        {
            var product = await _productsService.GetProductAsync(id);

            if (product == null)
            {
                Console.WriteLine($"Product with id {id} not found");
                return;
            }

            _productPrinter.PrintProduct(product);
        }
    }
}
