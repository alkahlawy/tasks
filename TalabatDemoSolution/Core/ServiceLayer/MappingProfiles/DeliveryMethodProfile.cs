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
    public class DeliveryMethodProfile : Profile
    {
        public DeliveryMethodProfile()
        {
            CreateMap<DeliveryMethod, DeliveryMethodDto>().ReverseMap();
        }
    }
}
