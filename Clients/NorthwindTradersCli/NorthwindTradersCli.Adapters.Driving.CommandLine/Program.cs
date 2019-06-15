using System;
using System.Threading;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintLoad(27);
            Console.WriteLine("Welcome to Northwind Traders CLI");
            Console.WriteLine("Type 'help' to print list of commands");

            while (true)
            {
                var command = Console.ReadLine();
                switch (command)
                {
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
