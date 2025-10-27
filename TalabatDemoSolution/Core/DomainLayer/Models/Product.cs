
namespace DomainLayer.Models
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = null!;
        public int TypeId { get; set; }
        public int BrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public ProductType ProductType { get; set; }
    }
}
