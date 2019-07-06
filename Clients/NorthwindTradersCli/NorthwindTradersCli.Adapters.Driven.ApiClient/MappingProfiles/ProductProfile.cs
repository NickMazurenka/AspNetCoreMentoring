using AutoMapper;
using NorthwindTradersCli.Adapters.Driven.ApiClient.Models.Product;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Adapters.Driven.ApiClient.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductGetDto, Product>();
        }
    }
}
