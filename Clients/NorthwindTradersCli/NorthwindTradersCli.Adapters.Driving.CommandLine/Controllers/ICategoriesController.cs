using System.Threading.Tasks;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine.Controllers
{
    public interface ICategoriesController
    {
        Task Get();
        Task Get(int id);
    }
}
