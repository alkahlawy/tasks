using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace PersistenceLayer
{
    public class DataSeeding : IDataSeeding
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly ILogger<DataSeeding> _logger;

        public DataSeeding(StoreDbContext storeDbContext, ILogger<DataSeeding> logger)
        {
            _storeDbContext = storeDbContext;
            _logger = logger;
        }

        public async Task SeedDataAsync()
        {
            try
            {
                var pending = await _storeDbContext.Database.GetPendingMigrationsAsync();
                if (pending.Any())
                    await _storeDbContext.Database.MigrateAsync();

                if (!await _storeDbContext.ProductBrands.AnyAsync())
                {
                    var brandsPath = Path.GetFullPath(Path.Combine("Data", "DataSeeding", "brands.json"));
                    if (File.Exists(brandsPath))
                    {
                        await using var productBrandsData = File.OpenRead(brandsPath);
                        var productBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productBrandsData);
                        if (productBrands != null && productBrands.Any())
                        {
                            await _storeDbContext.ProductBrands.AddRangeAsync(productBrands);
                        }
                    }
                    else
                    {
                        _logger.LogWarning("Brands seed file not found at {Path}", brandsPath);
                    }
                }

                if (!await _storeDbContext.ProductTypes.AnyAsync())
                {
                    var typesPath = Path.GetFullPath(Path.Combine( "Data", "DataSeeding", "types.json"));
                    if (File.Exists(typesPath))
                    {
                        await using var productTypesData = File.OpenRead(typesPath);
                        var productTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(productTypesData);
                        if (productTypes != null && productTypes.Any())
                        {
                            await _storeDbContext.ProductTypes.AddRangeAsync(productTypes);
                        }
                    }
                    else
                    {
                        _logger.LogWarning("Types seed file not found at {Path}", typesPath);
                    }
                }

                if (!await _storeDbContext.Products.AnyAsync())
                {
                    var productsPath = Path.GetFullPath(Path.Combine( "Data", "DataSeeding", "products.json"));
                    if (File.Exists(productsPath))
                    {
                        await using var productsData = File.OpenRead(productsPath);
                        var products = await JsonSerializer.DeserializeAsync<List<Product>>(productsData);
                        if (products != null && products.Any())
                        {
                            await _storeDbContext.Products.AddRangeAsync(products);
                        }
                    }
                    else
                    {
                        _logger.LogWarning("Products seed file not found at {Path}", productsPath);
                    }
                }

                await _storeDbContext.SaveChangesAsync();
                _logger.LogInformation("Data seeding completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }
    }
}
