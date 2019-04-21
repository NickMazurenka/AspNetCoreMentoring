using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTraders.Domain.Products;

namespace NorthwindTraders.Application.Products
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> CreateProductAsync(Product product);
        Task<Product> GetProductAsync(int productId);
        Task<Product> UpdateProductAsync(Product product);
        Task<int> DeleteProductAsync(int productId);
    }
}
