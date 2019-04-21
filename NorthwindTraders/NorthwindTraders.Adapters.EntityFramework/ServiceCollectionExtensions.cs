using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NorthwindTraders.Adapters.EntityFramework.Repositories;
using NorthwindTraders.Application.Categories;
using NorthwindTraders.Application.Products;
using NorthwindTraders.Application.Suppliers;

namespace NorthwindTraders.Adapters.EntityFramework
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkAdapter(this IServiceCollection services, string sqlServerConnectionString)
        {
            services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(sqlServerConnectionString));
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ISuppliersRepository, SuppliersRepository>();

            return services;
        }
    }
}
