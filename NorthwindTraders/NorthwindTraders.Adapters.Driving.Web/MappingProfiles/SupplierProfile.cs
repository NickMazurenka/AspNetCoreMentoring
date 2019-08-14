using AutoMapper;
using NorthwindTraders.Adapters.Driving.Web.ViewModels.Supplier;
using NorthwindTraders.Domain.Suppliers;

namespace NorthwindTraders.Adapters.Driving.Web.MappingProfiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierViewModel>();
        }
    }
}
