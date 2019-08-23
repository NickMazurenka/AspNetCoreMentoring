using AutoMapper;
using NorthwindTraders.Adapters.Driving.Web.ViewModels.Administration;
using NorthwindTraders.Domain.Administration;

namespace NorthwindTraders.Adapters.Driving.Web.MappingProfiles
{
    public class AdministrationProfile : Profile
    {
        public AdministrationProfile()
        {
            CreateMap<UserInfo, UserInfoViewModel>();
        }
    }
}
