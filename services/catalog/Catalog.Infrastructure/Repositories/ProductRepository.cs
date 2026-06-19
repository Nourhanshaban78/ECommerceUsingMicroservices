using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using Catalog.Infrastructure.Data.Context;
using MongoDB.Driver;
using MongoDB.Driver.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository, IBrandRepository, ITypeRepository
    {
        public ICatalogContext _context { get; set; }
        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
             await _context.Products.InsertOneAsync(product); 
            return product;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var deleteProduct = await _context.Products.DeleteOneAsync(p => p.Id == id);
            return deleteProduct.IsAcknowledged && deleteProduct.DeletedCount > 0;
        }

        public async Task<IEnumerable<ProductBrand>> GetAllBrands()
        {
            return await _context.Brands.Find(p => true).ToListAsync();
        }

        public async Task<Pagination<Product>> GetAllProduct(CatalogSpecParam catalogSpecParam)
        {
            var builder = Builders<Product>.Filter;
            var filter = builder.Empty;
            if (!string.IsNullOrEmpty(catalogSpecParam.Search))
                filter = filter & builder.Where(p => p.Name.ToLower().Contains(catalogSpecParam.Search.ToLower()));
            if (!string.IsNullOrEmpty(catalogSpecParam.BrandId))
            {
                var brandFilter = builder.Eq(p => p.Brand.Id, catalogSpecParam.BrandId);
                    filter &= brandFilter;
            }
            if (!string.IsNullOrEmpty(catalogSpecParam.TypeId))
            {
                var typeFilter = builder.Eq(p => p.Type.Id, catalogSpecParam.TypeId);
                filter &= typeFilter;
            }

            var TotalItems = await _context.Products.CountDocumentsAsync(filter);
            var data = await DataFilter(catalogSpecParam, filter);


            return new Pagination<Product>
                (
                  catalogSpecParam.PageSize,
                  catalogSpecParam.PageIndex,
                  (int)TotalItems,
                  data
                
                );
        }

        public async Task<IEnumerable<ProductType>> GetAllTypes()
        {
            return await _context.Types.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByBrand(string brand)
        {
            return await _context.Products.Find(p => p.Brand.Name == brand).ToListAsync();
        }

        public async Task<Product> GetProductByID(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _context.Products.Find(p => p.Name == name).ToListAsync();

        }

        public async Task<bool> UpdateProduct(Product product)
        {
            
                var updateProduct = await _context.Products.ReplaceOneAsync(p => p.Id == product.Id,product);
                return updateProduct.IsAcknowledged && updateProduct.ModifiedCount > 0;

        }


        private async Task<IReadOnlyList<Product>> DataFilter(CatalogSpecParam catalogSpecParam,FilterDefinition<Product> filter)
        {
            var sortDefin = Builders<Product>.Sort.Ascending("Name");
            if (!string.IsNullOrEmpty(catalogSpecParam.Sort))
            {
                switch (catalogSpecParam.Sort)
                {
                    case "priceAsc":
                        sortDefin = Builders<Product>.Sort.Ascending(p => p.Price);
                        break;

                    case "priceDsc":
                        sortDefin = Builders<Product>.Sort.Descending(p => p.Price);
                        break;
                    default:
                        sortDefin = Builders<Product>.Sort.Ascending("Name");
                        break;

                }
            }

            return await _context.Products.Find(filter)
                .Sort(sortDefin).Skip(catalogSpecParam.PageSize *(catalogSpecParam.PageIndex - 1))
                .Limit(catalogSpecParam.PageSize).ToListAsync();
        }
            
            
    }
}
