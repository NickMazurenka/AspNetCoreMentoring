using System;
using System.Threading;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IFooService, FooService>()
                .AddSingleton<IBarService, BarService>()
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            //do the actual work here
            var bar = serviceProvider.GetService<IBarService>();

            .AddAutoMapper(typeof(Startup));

            PrintLoad(27);
            Console.WriteLine("Welcome to Northwind Traders CLI");
            Console.WriteLine("Type 'help' to print list of commands");

            while (true)
            {
                var command = Console.ReadLine();
                switch (command)
                {
                    case "categories":
                        return;
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
            Console.WriteLine("productes" +
                              " - lists all categories");
            Console.WriteLine("help - print help");
            Console.WriteLine("quit - exit the program");
        }

        static void PrintLoad(int loadLineLength)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("(");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(new string('.', loadLineLength));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(")");

            Console.Write(new string('\b', loadLineLength + 1));
            for (int i = 0; i < loadLineLength; i++)
            {
                Console.Write("#");
                Thread.Sleep(72);
            }
            Console.Write(new string('\b', loadLineLength + 3));
        }
    }
}
