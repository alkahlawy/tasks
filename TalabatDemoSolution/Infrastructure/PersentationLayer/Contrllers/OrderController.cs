using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer;
using Shared.DTOs.OrderDtos;

namespace PersentationLayer.Contrllers
{
    [Authorize]
    public class OrderController(IServiceManager _serviceManager) : ApiBaseController
    {
        
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto orderDto)
        {
            var orderToReturn = await _serviceManager.OrderService.CreateOrderAsync(orderDto,GetEmailFromToken());
            return Ok(orderToReturn);
        }

        
        [HttpGet("DeliveryMethods")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DeliveryMethodDto>>> GetDeliveryMethodsAsync()
        {
            var deliveryMethods = await _serviceManager.OrderService.GetDeliveryMethodsAsync();
            return Ok(deliveryMethods);
        }

        
        [HttpGet("{id:guid")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderById(Guid id)
        {
            var orderToReturn = await _serviceManager.OrderService.GetOrderByIdAsync(id);
            return Ok(orderToReturn);
        }

        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetAllOrders()
        {
            var orderToReturn = await _serviceManager.OrderService.GetAllOrdersAsync(GetEmailFromToken());
            return Ok(orderToReturn);
        }

    }
}
