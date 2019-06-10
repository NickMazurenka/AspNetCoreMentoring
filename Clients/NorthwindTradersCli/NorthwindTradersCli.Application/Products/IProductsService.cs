﻿using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Application.Products
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
