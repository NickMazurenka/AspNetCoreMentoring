using System.Threading.Tasks;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine.Controllers
{
    public interface IProductsController
    {
        Task Get();
        Task Get(int id);
    }
}
