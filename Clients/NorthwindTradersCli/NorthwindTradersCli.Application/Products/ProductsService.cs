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

        public async Task<Product> CreateProductAsync(Product product)
        {
            return await _productsRepository.CreateProduct(product);
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            return await _productsRepository.GetProduct(productId);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            return await _productsRepository.UpdateProduct(product);
        }

        public async Task<int> DeleteProductAsync(int productId)
        {
            return await _productsRepository.DeleteProduct(productId);
        }
    }
}
