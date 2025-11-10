using Shared.DTOs.BasketDtos;

namespace DomainLayer.Contracts
{
    public interface IBasketServices
    {
        Task<BasketDto> GetBasketAsync(string key);
        Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket);
        Task<bool> DeleteBasketAsync(string key);
    }
}
