using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTraders.Domain.Administration;

namespace NorthwindTraders.Application.Administration
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public async Task<IEnumerable<UserInfo>> GetUsersInfoAsync()
        {
            return await _userInfoRepository.GetUsersInfoAsync();
        }
    }
}
