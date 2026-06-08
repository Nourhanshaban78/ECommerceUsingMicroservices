using AutoMapper;
using Catalog.Application.Queries.TypesQueries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries.Types
{
    public class GetAllTypeQueryHandler : IRequestHandler<GetAllTypesQuery, IList<TypeResPonseDto>>
    {
        
        private readonly ITypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public GetAllTypeQueryHandler(ITypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }
        public async Task<IList<TypeResPonseDto>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var types = await _typeRepository.GetAllTypes();
            var typeResponseList = _mapper.Map<IList<ProductType>, IList<TypeResPonseDto>>(types.ToList());
            return typeResponseList;
        }
    }
}
