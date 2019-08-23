using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTraders.Domain.Administration;

namespace NorthwindTraders.Application.Administration
{
    public interface IUserInfoService
    {
        Task<IEnumerable<UserInfo>> GetUsersInfoAsync();
    }
}
