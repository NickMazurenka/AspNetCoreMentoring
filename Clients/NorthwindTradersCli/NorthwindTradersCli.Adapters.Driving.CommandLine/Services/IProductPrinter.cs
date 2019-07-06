using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine.Services
{
    public interface IProductPrinter
    {
        void PrintProduct(Product product);
    }
}
