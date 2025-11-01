using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer;
using Shared.DTOs;

namespace PersentationLayer
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager _serviceManager) : ControllerBase
    {
        // Get all products
        [HttpGet] // GET :: BaseUrl/api/products
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _serviceManager.ProductService.GetAllProductsAsync();
            return Ok(products);
        }

        // Get product by ID
        [HttpGet("{id}")] // GET :: BaseUrl/api/products/{id}
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            if (id < 1) return BadRequest("Invalid product ID.");

            var product = await _serviceManager.ProductService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // Get All Brands
        [HttpGet("brands")] // GET :: BaseUrl/api/products/brands
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var brands = await _serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(brands);
        }

        // Get All Types
        [HttpGet("types")] // GET :: BaseUrl/api/products/types
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var types = await _serviceManager.ProductService.GetAllTypesAsync();
            return Ok(types);
        }
    }
}
