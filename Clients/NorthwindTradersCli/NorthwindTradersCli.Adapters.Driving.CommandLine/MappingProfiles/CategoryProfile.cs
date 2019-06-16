using AutoMapper;
using NorthwindTraders.Adapters.Driving.Api.Models.Category;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTraders.Adapters.Driving.Api.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetDto>();
        }
    }
}
