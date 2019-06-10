using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Application.Suppliers
{
    public interface ISuppliersRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliersAsync();
    }
}
