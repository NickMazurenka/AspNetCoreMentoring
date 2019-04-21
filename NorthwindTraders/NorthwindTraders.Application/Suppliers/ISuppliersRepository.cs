using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTraders.Domain.Suppliers;

namespace NorthwindTraders.Application.Suppliers
{
    public interface ISuppliersRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliersAsync();
    }
}
