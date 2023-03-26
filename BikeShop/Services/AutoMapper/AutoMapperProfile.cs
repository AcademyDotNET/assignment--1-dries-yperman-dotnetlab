using AutoMapper;
using BikeShop.Data.Entities;
using BikeShop.Models;

namespace BikeShop.Services.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ShoppingItem, ShoppingItemDTO>().ReverseMap();
            CreateMap<ShoppingBag, ShoppingBagDTO>().ReverseMap();
        }
    }
}
