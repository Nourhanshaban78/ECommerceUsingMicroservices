using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Queries.BrandQueries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries.Brands
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, IList<BrandResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public GetAllBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<IList<BrandResponseDto>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetAllBrands();
            var brandResponseList = _mapper.Map<IList<ProductBrand>, IList<BrandResponseDto>>(brands.ToList());
            return brandResponseList;
        }
    }
}
