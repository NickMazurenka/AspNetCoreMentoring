using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Application.Suppliers
{
    public interface ISuppliersService
    {
        Task<IEnumerable<Supplier>> GetSuppliersAsync();
    }
}
