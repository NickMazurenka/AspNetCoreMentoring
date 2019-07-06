using AutoMapper;
using NorthwindTradersCli.Adapters.Driven.ApiClient.Models.Category;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Adapters.Driven.ApiClient.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryGetDto, Category>();
        }
    }
}
