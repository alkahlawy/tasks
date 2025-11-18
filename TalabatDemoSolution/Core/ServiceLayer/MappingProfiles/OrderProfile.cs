using AutoMapper;
using DomainLayer.Models.OrderModels;
using Shared.DTOs.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(dest => dest.DelviryMethod,
                           opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
                .ReverseMap();
        }
    }
}
