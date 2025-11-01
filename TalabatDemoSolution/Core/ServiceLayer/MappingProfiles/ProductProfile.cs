
using AutoMapper;
using DomainLayer.Models;
using Shared.DTOs;

namespace ServiceLayer.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<PictureUrlResolver>())
                .ReverseMap();
            CreateMap<ProductBrand, BrandDto>().ReverseMap();
            CreateMap<ProductType, TypeDto>().ReverseMap();
        }

    }
}
