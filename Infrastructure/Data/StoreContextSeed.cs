using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Core.Entities;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var productBrandsData =
                        await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/productBrands.json");
                    var productBrands = JsonConvert.DeserializeObject<List<ProductBrand>>(productBrandsData);
                    await context.ProductBrands.AddRangeAsync(productBrands);

                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var productTypesData =
                        await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/productTypes.json");
                    var productTypes = JsonConvert.DeserializeObject<List<ProductType>>(productTypesData);
                    await context.ProductTypes.AddRangeAsync(productTypes);

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                    await context.Products.AddRangeAsync(products);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.Log(LogLevel.Error, ex.Message);
            }
        }
    }
}
