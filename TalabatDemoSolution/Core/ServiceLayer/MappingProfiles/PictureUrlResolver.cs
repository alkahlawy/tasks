using AutoMapper;
using DomainLayer.Models.ProductModels;
using Microsoft.Extensions.Configuration;
using Shared.DTOs.ProductDtos;


namespace ServiceLayer.MappingProfiles
{
    internal class PictureUrlResolver(IConfiguration _config)
                        : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                var baseUrl = _config.GetSection("Urls")["BaseUrl"];
                return $"{baseUrl}{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
