using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductQueryParams
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public ProductSortingOptions SortingOptions { get; set; }
        public string? SearchTerm { get; set; }

        #region Pagination
        private const int DefaultPageSize = 5;
        private const int MaxPageSize = 10;
        public int PageIndex { get; set; } = 1;
        private int pageSize = DefaultPageSize;

        public int PageSize
        {
            get => pageSize;
            set => pageSize = (value > MaxPageSize) ? DefaultPageSize : value;
        } 
        #endregion


    }
}
