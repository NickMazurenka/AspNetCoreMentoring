using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindTraders.Application.Administration;
using NorthwindTraders.Domain.Administration;

namespace NorthwindTraders.Adapters.Driven.EntityFramework.Repositories
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly NorthwindContext _context;

        public UserInfoRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserInfo>> GetUsersInfoAsync()
        {
            return await _context.Users.Select(x => new UserInfo
            {
                UserName = x.UserName,
                Email = x.Email,
                EmailConfirmed = x.EmailConfirmed
            }).ToListAsync();
        }
    }
}
