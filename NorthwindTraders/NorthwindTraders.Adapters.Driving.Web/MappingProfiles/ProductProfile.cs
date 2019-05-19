using AutoMapper;
using NorthwindTraders.Adapters.Driving.Web.ViewModels.Product;
using NorthwindTraders.Domain.Products;

namespace NorthwindTraders.Adapters.Driving.Web.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductEditModel>();
            CreateMap<ProductEditModel, Product>();
            CreateMap<ProductCreateModel, Product>();
        }
    }
}
