using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace Catalog.Infrastructure.Data.Context
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<ProductBrand> Brands { get; }
        public IMongoCollection<ProductType> Types { get; }

        public CatalogContext(IConfiguration configuration)
        {
            // قراءة القيم مباشرة من الـ Configuration
            var connectionString = configuration["DatabaseSettings:ConnectionString"];
            var databaseName = configuration["DatabaseSettings:DatabaseName"];
            var brandsColl = configuration["DatabaseSettings:BrandsCollection"];
            var typesColl = configuration["DatabaseSettings:TypesCollection"];
            var productsColl = configuration["DatabaseSettings:ProductsCollection"];

            // سطر الطباعة هذا سيؤكد لكِ في لوج الدوكر أن العنوان أصبح صحيحاً
            Console.WriteLine($"[MONGO INFO] Connecting to: {connectionString} | DB: {databaseName}");

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            Brands = database.GetCollection<ProductBrand>(brandsColl);
            Types = database.GetCollection<ProductType>(typesColl);
            Products = database.GetCollection<Product>(productsColl);

            // تشغيل الـ Seed Data
            // ملحوظة: يفضل مستقبلاً جعل الـ Seed يتم خارج الـ Constructor بانتظار (await)
            // لتجنب مشاكل الـ Timeout أثناء بناء الكلاس.
            BrandContextSeed.SeedDataAsyc(Brands).Wait();
            TypeContextSeed.SeedDataAsyc(Types).Wait();
            ProductContextSeed.SeedDataAsyc(Products).Wait();
        }
    }
}