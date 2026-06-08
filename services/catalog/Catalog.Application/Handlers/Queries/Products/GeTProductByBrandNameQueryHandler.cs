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
    public class GeTProductByBrandNameQueryHandler : IRequestHandler<GetProductByBrandNameQuery, IList<ProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GeTProductByBrandNameQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IList<ProductResponseDto>> Handle(GetProductByBrandNameQuery request, CancellationToken cancellationToken)
        {
            var  ProductbrandName = await _productRepository.GetProductByBrand(request.BrandName);
            var BrandNameResponse = _mapper.Map<IList<ProductResponseDto>>(ProductbrandName);
            return BrandNameResponse;
        }
    }
}
