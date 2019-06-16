using AutoMapper;
using NorthwindTraders.Adapters.Driving.Api.Models.Product;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTraders.Adapters.Driving.Api.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductGetDto>();
            CreateMap<ProductPostDto, Product>();
        }
    }
}
