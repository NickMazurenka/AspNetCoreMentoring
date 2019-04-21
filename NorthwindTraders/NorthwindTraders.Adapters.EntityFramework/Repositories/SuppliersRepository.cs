using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindTraders.Application.Suppliers;
using NorthwindTraders.Domain.Suppliers;

namespace NorthwindTraders.Adapters.EntityFramework.Repositories
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
