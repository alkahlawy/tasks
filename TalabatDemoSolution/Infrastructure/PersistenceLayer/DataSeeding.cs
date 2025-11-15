using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using DomainLayer.Models.ProductModels;
using Microsoft.AspNetCore.Identity;
using DomainLayer.Models.IdentityModels;

namespace PersistenceLayer
{
    public class DataSeeding(StoreDbContext _storeDbContext,
                             ILogger<DataSeeding> _logger,
                             UserManager<ApplicationUser> _userManager,
                             RoleManager<IdentityRole> _roleManager
                             ) : IDataSeeding
    {

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

        public async Task SeedIdentityDataAsync()
        {
            try
            {
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                }
                if (_userManager.Users.Any())
                {
                    var user01 = new ApplicationUser()
                    {
                        Email = "mohamed@gmail.com",
                        DisplayName = "Moahmed",
                        PhoneNumber = "01123456789",
                        UserName = "mohamed"
                    };

                    var user02 = new ApplicationUser()
                    {
                        Email = "mahmoud@gmail.com",
                        DisplayName = "Mahmoud",
                        PhoneNumber = "01423456789",
                        UserName = "mahmoud"
                    };

                    await _userManager.CreateAsync(user01, "P@ssw0rd");
                    await _userManager.CreateAsync(user02, "P@ssw0rd");
                    await _userManager.AddToRoleAsync(user01, "SuperAdmin");
                    await _userManager.AddToRoleAsync(user02, "Admin");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
