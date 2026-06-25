using AutoMapper;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Handler.Queries
{
    public class GetBasketByNameQueryHandler : IRequestHandler<GetBasketByNameQuery, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public GetBasketByNameQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<ShoppingCartResponse> Handle(GetBasketByNameQuery request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _basketRepository.GetBasket(request.UserName);
            var ShoppingCartResponse = _mapper.Map<ShoppingCartResponse>(shoppingCart);
            return ShoppingCartResponse;
        }
    }
}
