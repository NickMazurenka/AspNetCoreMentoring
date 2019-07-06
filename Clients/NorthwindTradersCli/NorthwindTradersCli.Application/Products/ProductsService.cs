using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Application.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productsRepository.GetProducts();
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            return await _productsRepository.GetProduct(productId);
        }
    }
}
