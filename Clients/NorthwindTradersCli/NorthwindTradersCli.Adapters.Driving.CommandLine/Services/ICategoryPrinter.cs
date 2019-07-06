using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine.Services
{
    public interface ICategoryPrinter
    {
        void PrintCategory(Category category);
    }
}
