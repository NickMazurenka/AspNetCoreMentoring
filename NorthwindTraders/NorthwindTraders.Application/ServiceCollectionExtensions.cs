using Microsoft.Extensions.DependencyInjection;
using NorthwindTraders.Application.Categories;
using NorthwindTraders.Application.Products;
using NorthwindTraders.Application.Suppliers;
using NorthwindTraders.Application.UserNotification;

namespace NorthwindTraders.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<ISuppliersService, SuppliersService>();
            services.AddTransient<ISendEmailService, SendEmailService>();

            return services;
        }
    }
}
