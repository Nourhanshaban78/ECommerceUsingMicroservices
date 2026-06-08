using AutoMapper;
using Catalog.Application.Queries.ProductQueries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries.Products
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IList<ProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IList<ProductResponseDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProduct();
            var productResponseList = _mapper.Map<IList<ProductResponseDto>>(products);
            return productResponseList; 
        }
    }
}
