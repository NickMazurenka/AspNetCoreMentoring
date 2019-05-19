using System.IO;
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
            CreateMap<Category, CategoryEditModel>().ForMember(x => x.Picture, opt => opt.Ignore());
            CreateMap<CategoryEditModel, Category>().ForMember(x => x.Picture, opt => opt.Ignore());
            CreateMap<CategoryCreateModel, Category>();
        }
    }
}
