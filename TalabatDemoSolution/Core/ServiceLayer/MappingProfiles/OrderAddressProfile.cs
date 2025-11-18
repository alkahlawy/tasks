using AutoMapper;
using DomainLayer.Models.IdentityModels;
using DomainLayer.Models.OrderModels;
using Shared.DTOs.IdentityDtos;

namespace ServiceLayer.MappingProfiles
{
    public class OrderAddressProfile : Profile
    {
        public OrderAddressProfile()
        {
            CreateMap<OrderAddress, AddressDto>().ReverseMap();
        }
    }
}
