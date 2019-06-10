﻿using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Application.Products
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProduct(int productId);
        Task<Product> UpdateProduct(Product product);
        Task<int> DeleteProduct(int productId);
    }
}
