using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.BasketModels;
using Shared.DTOs.BasketDtos;

namespace ServiceLayer
{
    public class BasketServices(IBasketRepository _repository, IMapper _mapper) : IBasketServices
    {
        public async Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket)
        {
            var customerBasket = _mapper.Map<CustomerBasket>(basket);
            var createdOrUpdatedBasket = await _repository.CreateOrUpdateBasketAsync(customerBasket);   
            if(createdOrUpdatedBasket is not null) 
                return await GetBasketAsync(basket.Id);
            else
                throw new Exception("Failed to create or update basket. Try again later.");
        }

        public async Task<bool> DeleteBasketAsync(string key)
            => await _repository.DeleteBasketAsync(key);

        public async Task<BasketDto> GetBasketAsync(string key)
        {
            var basket = await _repository.GetBasketAsync(key);
            if (basket is not null) return _mapper.Map<BasketDto>(basket);
            else throw new BasketNotFoundException(key);
        }
    }
}
