using AutoMapper;
using Catalog.Application.Commands.Products;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Commands.Products
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
       

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }
        async Task<bool> IRequestHandler<UpdateProductCommand, bool>.Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updateProduct = await _productRepository.UpdateProduct(new Core.Entities.Product()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Brand = request.Brand,
                ImageFile = request.ImageFile,
                Price = request.Price,
                Summary = request.Summary,
                Type = request.Type


            });
            return true;
        }
    }
}
