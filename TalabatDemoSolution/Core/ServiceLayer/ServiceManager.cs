using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ServiceAbstractionLayer;

namespace ServiceLayer
{
    public class ServiceManager(IUnitOfWork _unitOfWork,
                                IMapper _mapper,
                                IBasketRepository _basketRepository,
                                IConfiguration _configuration,
                                UserManager<ApplicationUser> _userManager) : IServiceManager
    {
        private readonly Lazy<IProductService> _lazyProductService
            = new(() => new ProductService(_unitOfWork, _mapper));
        public IProductService ProductService => _lazyProductService.Value;

        private readonly Lazy<IBasketServices> _lazyBasketService
           = new(() => new BasketServices(_basketRepository, _mapper));
        public IBasketServices BasketService => _lazyBasketService.Value;

        private readonly Lazy<IAuthenticationService> _lazyAuthenticationService
           = new(() => new AuthenticationService(_userManager, _configuration, _mapper));
        public IAuthenticationService AuthenticationService => _lazyAuthenticationService.Value;

        private readonly Lazy<IOrderService> _lazyOrderService
          = new(() => new OrderService(_mapper,_basketRepository,_unitOfWork));
        public IOrderService OrderService => _lazyOrderService.Value;
    }
}
