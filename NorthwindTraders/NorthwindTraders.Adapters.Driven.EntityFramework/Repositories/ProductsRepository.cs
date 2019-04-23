using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindTraders.Application.Products;
using NorthwindTraders.Domain.Products;

namespace NorthwindTraders.Adapters.EntityFramework.Repositories
{
    internal class ProductsRepository : IProductsRepository
    {
        private readonly NorthwindContext _context;

        public ProductsRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Include(p => p.Category).Include(p => p.Supplier).ToListAsync();
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == productId);
        }

        public async Task<int> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return productId;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
