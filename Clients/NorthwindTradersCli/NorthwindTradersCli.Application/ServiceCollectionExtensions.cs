﻿using Microsoft.Extensions.DependencyInjection;
using NorthwindTradersCli.Application.Categories;
using NorthwindTradersCli.Application.Products;

namespace NorthwindTradersCli.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IProductsService, ProductsService>();

            return services;
        }
    }
}
