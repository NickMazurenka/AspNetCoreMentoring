using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindTradersCli.Adapters.Driven.ApiClient.Repositories
{
    internal class SuppliersRepository : ISuppliersRepository
    {
        private readonly NorthwindContext _context;

        public SuppliersRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }
    }
}
