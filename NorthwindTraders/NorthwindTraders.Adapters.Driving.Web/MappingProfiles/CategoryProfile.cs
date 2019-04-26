using AutoMapper;
using NorthwindTraders.Adapters.Driving.Web.ViewModels.Category;
using NorthwindTraders.Domain.Categories;

namespace NorthwindTraders.Adapters.Driving.Web.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryEditModel, Category>();
            CreateMap<CategoryCreateModel, Category>();
        }
    }
}
