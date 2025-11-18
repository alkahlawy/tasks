using Shared.DTOs.OrderDtos;


namespace ServiceAbstractionLayer
{
    public interface IOrderService
    {
        // Create Order
        Task<OrderToReturnDto> CreateOrderAsync(OrderDto orderDto, string email);
        Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodsAsync();
        Task<IEnumerable<OrderToReturnDto>> GetAllOrdersAsync(string email);
        Task<OrderToReturnDto> GetOrderByIdAsync(Guid id);
    }
}
