using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Application.Suppliers
{
    public class SuppliersService : ISuppliersService
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersAsync()
        {
            return await _suppliersRepository.GetSuppliersAsync();
        }
    }
}
