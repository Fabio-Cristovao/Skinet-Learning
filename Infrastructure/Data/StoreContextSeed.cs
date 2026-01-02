using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/seedData/products.json");
                var products = JsonSerializer.Deserialize<List<ProductDTO>>(productsData);

                if (products == null) return;

                context.AddRange(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
