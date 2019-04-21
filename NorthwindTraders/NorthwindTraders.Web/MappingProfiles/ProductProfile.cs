using AutoMapper;
using NorthwindTraders.Domain.Products;
using NorthwindTraders.Web.ViewModels.Product;

namespace NorthwindTraders.Web.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductEditModel, Product>();
            CreateMap<ProductCreateModel, Product>();
        }
    }
}
