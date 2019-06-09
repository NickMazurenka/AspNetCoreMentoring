using AutoMapper;
using NorthwindTraders.Adapters.Driving.Api.Models.Category;
using NorthwindTraders.Domain.Categories;

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
