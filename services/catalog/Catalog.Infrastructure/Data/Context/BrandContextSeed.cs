using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Context
{
    public static class BrandContextSeed
    {
        public  static async Task SeedDataAsyc(IMongoCollection<ProductBrand> brandCollection)
        {
            var hasBrands = await brandCollection.Find( _ => true).AnyAsync();
            if (hasBrands)
                return;
            //To read File Path of seeding data
            var filePath = Path.Combine("Data", "SeedData", "brands.json");
            if(!File.Exists(filePath))
            {
                Console.WriteLine($"seed file not exists :{filePath}");
                return;
            }
            var brandData = await File.ReadAllTextAsync(filePath);
            var brands = JsonSerializer.Deserialize <List<ProductBrand>>(brandData);
            if(brands?.Any() is true)
            {
                await brandCollection.InsertManyAsync(brands);
            }
        }
    }
}
