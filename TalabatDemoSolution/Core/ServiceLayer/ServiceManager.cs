using AutoMapper;
using DomainLayer.Contracts;
using ServiceAbstractionLayer;

namespace ServiceLayer
{
    public class ServiceManager(IUnitOfWork _unitOfWork,
                                IMapper _mapper,
                                IBasketRepository _basketRepository) : IServiceManager
    {
        private readonly Lazy<IProductService> _lazyProductService
            = new(() => new ProductService(_unitOfWork, _mapper));
        public IProductService ProductService => _lazyProductService.Value;

        private readonly Lazy<IBasketServices> _lazyBasketService
           = new(() => new BasketServices(_basketRepository, _mapper));
        public IBasketServices BasketService => _lazyBasketService.Value;
    }
}
