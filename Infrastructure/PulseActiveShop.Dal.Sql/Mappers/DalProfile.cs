using AutoMapper;
using Domain = PulseActiveShop.Core.Entities;
using EF = PulseActiveShop.Dal.Sql.Entities;

namespace PulseActiveShop.Dal.Sql.Mappers
{
    public class DalProfile : Profile
    {
        public DalProfile()
        {
            CreateMap<EF.ProductType, Domain.ProductType>().ReverseMap();
            CreateMap<EF.Brand, Domain.ProductBrand>().ReverseMap();
            CreateMap<EF.Product, Domain.Product>().ReverseMap();
            CreateMap<EF.Address, Domain.Address>().ReverseMap();
            CreateMap<EF.Order, Domain.Order>().ReverseMap();
            CreateMap<EF.BasketItem, Domain.BasketItem>().ReverseMap();
            CreateMap<EF.Basket, Domain.Basket>().ReverseMap();
        }
    }
}
