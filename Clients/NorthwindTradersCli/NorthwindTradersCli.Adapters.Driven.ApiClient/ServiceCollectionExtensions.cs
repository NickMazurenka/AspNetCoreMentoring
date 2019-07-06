using System;
using System.Net.Http.Headers;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NorthwindTradersCli.Adapters.Driven.ApiClient.Repositories;
using NorthwindTradersCli.Application.Categories;
using NorthwindTradersCli.Application.Products;

namespace NorthwindTradersCli.Adapters.Driven.ApiClient
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiClientAdapter(this IServiceCollection services, string apiUrl)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpClient("northwind", client =>
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();

            return services;
        }
    }
}
