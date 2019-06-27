using AutoMapper;
using NorthwindTradersCli.Adapters.Driving.CommandLine.Models.Product;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine.MappingProfiles
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
