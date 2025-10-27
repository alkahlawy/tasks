using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System.Text.Json;

namespace PersistenceLayer
{
    public class DataSeeding(StoreDbContext _storeDbContext) : IDataSeeding
    {
        public void SeedData()
        {
            try
            {
                if (_storeDbContext.Database.GetPendingMigrations().Any())
                    _storeDbContext.Database.Migrate();

                if (!_storeDbContext.ProductBrands.Any())
                {
                    var productBrandsData = File.ReadAllText("../Infrastructure/PersistenceLayer/DataSeeding/brands.json");
                    var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsData);
                    if (productBrands != null && productBrands.Any())
                    {
                        _storeDbContext.ProductBrands.AddRange(productBrands);
                    }
                }

                if (!_storeDbContext.ProductTypes.Any())
                {
                    var productTypesData = File.ReadAllText("../Infrastructure/PersistenceLayer/DataSeeding/types.json");
                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypesData);
                    if (productTypes != null && productTypes.Any())
                    {
                        _storeDbContext.ProductTypes.AddRange(productTypes);
                    }
                }
                if (!_storeDbContext.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/PersistenceLayer/DataSeeding/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    if (products != null && products.Any())
                    {
                        _storeDbContext.Products.AddRange(products);
                    }
                }
                _storeDbContext.SaveChanges();
            }
            catch (Exception)
            {

                // TODO
            }
        }
    }
}
