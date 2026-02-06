using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Stationery.PaperStore.Core.Entities;
using Stationery.PaperStore.Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Stationery.PaperStore.Infrastructure.Data
{
    public class StationeryStoreContextSeed
    {
        public static async Task SeedAsync(StationeryStoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Stationery/PaperStore/Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Stationery/PaperStore/Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Stationery/PaperStore/Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                if (!context.DeliveryMethods.Any())
                {
                    var deliveryData = File.ReadAllText("../Stationery/PaperStore/Infrastructure/Data/SeedData/delivery.json");

                    var DeliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);

                    foreach (var item in DeliveryMethods)
                    {
                        context.DeliveryMethods.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StationeryStoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}