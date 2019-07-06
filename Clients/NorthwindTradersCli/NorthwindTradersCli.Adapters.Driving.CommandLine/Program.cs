using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthwindTradersCli.Adapters.Driven.ApiClient;
using NorthwindTradersCli.Adapters.Driving.CommandLine.Controllers;
using NorthwindTradersCli.Adapters.Driving.CommandLine.Services;
using NorthwindTradersCli.Application;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            var services = new ServiceCollection();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddApplicationCore();
            services.AddApiClientAdapter(configuration.GetConnectionString("NorthwindTradersApi"));
            services.AddTransient<IProductPrinter, ProductPrinter>();
            services.AddTransient<ICategoryPrinter, CategoryPrinter>();
            services.AddTransient<ICategoriesController, CategoriesController>();
            services.AddTransient<IProductsController, ProductsController>();

            var container = services.BuildServiceProvider();


            Console.WriteLine("Welcome to Northwind Traders CLI");
            Console.WriteLine("Type 'help' to print list of commands");

            while (true)
            {
                var request = Console.ReadLine() ?? "";
                var command = request.Split().First();
                switch (command)
                {
                    case "products":
                        await container.GetRequiredService<IProductsController>().Get();
                        break;
                    case "product":
                    {
                        if (!int.TryParse(request.Split().Last(), out var id))
                        {
                            Console.WriteLine("Invalid command");
                            break;
                        }

                        await container.GetRequiredService<IProductsController>().Get(id);
                        break;
                    }
                    case "categories":
                        await container.GetRequiredService<ICategoriesController>().Get();
                        break;
                    case "category":
                    {
                        if (!int.TryParse(request.Split().Last(), out var id))
                        {
                            Console.WriteLine("Invalid command");
                            break;
                        }

                        await container.GetRequiredService<ICategoriesController>().Get(id);
                        break;
                    }
                    case "help":
                        PrintHelp();
                        break;
                    case "quit":
                        return;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }

        static void PrintHelp()
        {
            Console.WriteLine("categories - lists all categories");
            Console.WriteLine("category {id} - output category with specified id");
            Console.WriteLine("products - lists all products");
            Console.WriteLine("product {id} - output product with specified id");
            Console.WriteLine("help - print help");
            Console.WriteLine("quit - exit the program");
        }
    }
}
