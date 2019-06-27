using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using NorthwindTradersCli.Adapters.Driven.ApiClient.Repositories;
using NorthwindTradersCli.Application.Categories;

namespace NorthwindTradersCli.Adapters.Driven.ApiClient
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiClientAdapter(this IServiceCollection services, string apiUrl)
        {
            services.AddHttpClient("northwind", client =>
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();

            return services;
        }
    }
}
