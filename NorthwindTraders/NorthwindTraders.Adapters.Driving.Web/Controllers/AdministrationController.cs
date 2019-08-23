using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthwindTraders.Adapters.Driving.Web.ViewModels.Administration;
using NorthwindTraders.Application.Administration;

namespace NorthwindTraders.Adapters.Driving.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IMapper _mapper;

        public AdministrationController(IUserInfoService userInfoService, IMapper mapper)
        {
            _userInfoService = userInfoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _userInfoService.GetUsersInfoAsync();
            return View(_mapper.Map<IEnumerable<UserInfoViewModel>>(data));
        }
    }
}
