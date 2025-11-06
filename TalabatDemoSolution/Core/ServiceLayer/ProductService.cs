using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstractionLayer;
using ServiceLayer.Specifications;
using Shared;
using Shared.DTOs;

namespace ServiceLayer
{
    public class ProductService(IUnitOfWork _unitOfWork,
                                IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<BrandDto>>(brands);
        }

        public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams)
        {
            // Create a specification to include related entities if necessary
            var specification = new ProductWithBrandAndTypeSpecification(queryParams);

            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(specification);
            var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(products);
            return new PaginatedResult<ProductDto>(mappedProducts, 0, queryParams.PageSize, queryParams.PageIndex);
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<TypeDto>>(types);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var specification = new ProductWithBrandAndTypeSpecification(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specification);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
