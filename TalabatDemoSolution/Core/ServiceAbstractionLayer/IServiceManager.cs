
using DomainLayer.Contracts;

namespace ServiceAbstractionLayer
{
    public interface IServiceManager
    {
        public IProductService ProductService { get; }
        public IBasketServices BasketService { get; }
        public IAuthenticationService AuthenticationService { get; }
        public IOrderService OrderService { get; }

    }
}
