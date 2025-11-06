using DomainLayer.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Specifications
{
    internal class ProductWithBrandAndTypeSpecification : BaseSpecifications<Product, int>
    {
        public ProductWithBrandAndTypeSpecification() : base(null)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }

        public ProductWithBrandAndTypeSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }

        public ProductWithBrandAndTypeSpecification(ProductQueryParams queryParams)
            : base(p =>
                (!queryParams.BrandId.HasValue || p.BrandId == queryParams.BrandId.Value) &&
                (!queryParams.TypeId.HasValue || p.TypeId == queryParams.TypeId.Value) &&
                (!string.IsNullOrEmpty(queryParams.SearchTerm) || p.Name.ToLower().Contains(queryParams.SearchTerm.ToLower())))
        {

            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            switch (queryParams.SortingOptions)
            {
                case ProductSortingOptions.PriceAsc:
                    ApplyOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    ApplyOrderByDescending(p => p.Price);
                    break;
                case ProductSortingOptions.NameAsc:
                    ApplyOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    ApplyOrderByDescending(p => p.Name);
                    break;
                case ProductSortingOptions.BrandAsc:
                    ApplyOrderBy(p => p.ProductBrand.Name);
                    break;
                case ProductSortingOptions.BrandDesc:
                    ApplyOrderByDescending(p => p.ProductBrand.Name);
                    break;
                default:
                    ApplyOrderBy(p => p.Name);
                    break;
            }
        }
    }
}
