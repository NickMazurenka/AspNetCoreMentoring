using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTraders.Domain.Suppliers;

namespace NorthwindTraders.Application.Suppliers
{
    public interface ISuppliersService
    {
        Task<IEnumerable<Supplier>> GetSuppliersAsync();
    }
}
