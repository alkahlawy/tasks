using AutoMapper;
using DomainLayer.Models.IdentityModels;
using Shared.DTOs.IdentityDtos;

namespace ServiceLayer.MappingProfiles
{
    public class IdentityAddressProfile : Profile
    {
        public IdentityAddressProfile()
        {
            CreateMap<AddressDto,Address>().ReverseMap();
        }
    }
}
