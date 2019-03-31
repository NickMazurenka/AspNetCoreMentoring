using AutoMapper;
using NorthwindTraders.Domain.Entities;
using NorthwindTraders.Web.ViewModels;
using NorthwindTraders.Web.ViewModels.Category;

namespace NorthwindTraders.Web.MappingProfiles
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
