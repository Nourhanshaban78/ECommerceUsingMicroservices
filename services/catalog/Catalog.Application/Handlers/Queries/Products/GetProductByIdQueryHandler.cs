using AutoMapper;
using Catalog.Application.Queries.ProductQueries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries.Products
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetproductByNameQuery, ProductResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponseDto> Handle(GetproductByNameQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByID(request.Id);
            var ProdcutResponse = _mapper.Map<ProductResponseDto>(product);
            return ProdcutResponse;
        }
    }
}
