using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer;
using Shared.DTOs.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersentationLayer.Contrllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasket(string key)
        {
            var basket = await _serviceManager.BasketService.GetBasketAsync(key);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdateBasket(BasketDto basketDto)
        {
            var updatedBasket = await _serviceManager.BasketService.CreateOrUpdateBasketAsync(basketDto);
            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string key)
        {
            var result = await _serviceManager.BasketService.DeleteBasketAsync(key);
            return Ok(result);
        }
    }
}
