using DomainLayer.Models.ProductModels;
using Shared;
using System.Linq.Expressions;


namespace ServiceLayer.Specifications
{
    public class ProductCountSpecification : BaseSpecifications<Product, int>
    {
        public ProductCountSpecification(ProductQueryParams queryParams)
            : base(p =>
                (!queryParams.BrandId.HasValue || p.BrandId == queryParams.BrandId.Value) &&
                (!queryParams.TypeId.HasValue || p.TypeId == queryParams.TypeId.Value) &&
                (!string.IsNullOrEmpty(queryParams.SearchTerm) || p.Name.ToLower().Contains(queryParams.SearchTerm.ToLower())))
        {
        }
    }
}
