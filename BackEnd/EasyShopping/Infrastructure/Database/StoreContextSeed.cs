using EasyShopping.Core.Model.Product;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EasyShopping.Infrastructure.Database
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsdata = File.ReadAllText("../Infrastructure/SeedData/productbrands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);
                     context.ProductBrands.AddRange(brands);
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var typesdata = File.ReadAllText("../Infrastructure/SeedData/producttypes.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);
                    context.ProductTypes.AddRange(types);
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var productsdata = File.ReadAllText("../Infrastructure/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsdata);
                    context.Products.AddRange(products);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
