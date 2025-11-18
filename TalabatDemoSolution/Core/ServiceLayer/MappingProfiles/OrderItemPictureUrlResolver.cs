using AutoMapper;
using DomainLayer.Models.OrderModels;
using DomainLayer.Models.ProductModels;
using Microsoft.Extensions.Configuration;
using Shared.DTOs.OrderDtos;
using Shared.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.MappingProfiles
{
    public class OrderItemPictureUrlResolver(IConfiguration _config) 
                        : IValueResolver<OrderItem, OrderItemDto, string>
    {
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Product.PictureUrl))
            {
                var baseUrl = _config.GetSection("Urls")["BaseUrl"];
                return $"{baseUrl}{source.Product.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
