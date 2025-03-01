using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order_Aggregate;
using Microsoft.EntityFrameworkCore;

namespace Talabat.Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext dbContext)
        {
            await SeedDataAsync<ProductBrand>(dbContext, "brands.json");
            await SeedDataAsync<ProductCategory>(dbContext, "categories.json");
            await SeedDataAsync<Product>(dbContext, "products.json");
            await SeedDataAsync<DeliveryMethod>(dbContext, "delivery.json");
        }

        private static async Task SeedDataAsync<T>(StoreContext dbContext, string fileName) where T : class
        {
            if (await dbContext.Set<T>().AnyAsync()) return;

            var filePath = Path.Combine("../Talabat.Repository/Data/DataSeed", fileName);
            if (!File.Exists(filePath)) return;

            var jsonData = await File.ReadAllTextAsync(filePath);
            var entities = JsonSerializer.Deserialize<List<T>>(jsonData);

            if (entities is { Count: > 0 })
            {
                await dbContext.Set<T>().AddRangeAsync(entities);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
