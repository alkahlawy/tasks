using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.OrderModels;
using DomainLayer.Models.ProductModels;
using ServiceAbstractionLayer;
using ServiceLayer.Specifications.OrderModuleSpecification;
using Shared.DTOs.OrderDtos;

namespace ServiceLayer
{
    public class OrderService(IMapper _mapper,
                              IBasketRepository _basketRepository,
                              IUnitOfWork _unitOfWork)
                : IOrderService
    {
        public async Task<OrderToReturnDto> CreateOrderAsync(OrderDto orderDto, string email)
        {
            // get address
            var orderAddress = _mapper.Map<OrderAddress>(orderDto.Addrss);

            // get basket
            var basket = await _basketRepository.GetBasketAsync(orderDto.BasketId) ?? 
                                throw new BasketNotFoundException(orderDto.BasketId);

            // create order items
            List<OrderItem> items = [];
            var productRepo = _unitOfWork.GetRepository<Product, int>();
            foreach (var basketItem in items)
            {
                var originalProduct = await productRepo.GetByIdAsync(basketItem.Id) ??
                                            throw new ProductNotFoundException(basketItem.Id);

                var orderItem = new OrderItem()
                {
                    Product = new ProductItemOrdered()
                    {
                        ProductName = originalProduct.Name,
                        ProductId = originalProduct.Id,
                        PictureUrl = originalProduct.PictureUrl,
                    },
                    Price = originalProduct.Price,
                    Quantity = basketItem.Quantity,
                };

                items.Add(orderItem);

            }

            // get delivery method
            var deliveryMethod = await _unitOfWork
                                       .GetRepository<DeliveryMethod, int>()
                                       .GetByIdAsync(orderDto.DeliveryMethodId) ??
                                       throw new DeliveryMethodNotFoundException(orderDto.DeliveryMethodId);

            // Calc subtotal
            var subtotal = items.Sum(i => i.Quantity * i.Price);


            // create order obj
            var order = new Order(email,
                                  items,
                                  orderAddress,
                                  deliveryMethod,
                                  subtotal);

            // add the order
            await _unitOfWork.GetRepository<Order, Guid>().AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<OrderToReturnDto>(order);    
        }

        public async Task<OrderToReturnDto> GetOrderByIdAsync(Guid id)
        {
            var specs = new OrderSpecification(id);
            var order = await _unitOfWork.GetRepository<Order, Guid>()
                                         .GetByIdAsync(specs) ?? 
                                         throw new OrderNotFoundException(id);

            return _mapper.Map<OrderToReturnDto>(order);
        }

        public async Task<IEnumerable<OrderToReturnDto>> GetAllOrdersAsync(string email)
        {
            var specs = new OrderSpecification(email);
            var orders = await _unitOfWork.GetRepository<Order, Guid>().GetAllAsync(specs);
            return _mapper.Map<IEnumerable<OrderToReturnDto>>(orders);
        }

        public async Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodsAsync()
        {
            var deliveryMethods = await _unitOfWork.GetRepository<DeliveryMethod, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<DeliveryMethodDto>>(deliveryMethods);
        }
    }
}
