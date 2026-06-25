using AutoMapper;
using Basket.Application.Commands;
using Basket.Application.Responses;
using Basket.Domain.Entities;
using Basket.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Handler.Commands
{
    public class UpdateShoppingCartCommandHandler : IRequestHandler<UpdateShoppingCartCommand, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public UpdateShoppingCartCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<ShoppingCartResponse> Handle(UpdateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var CreateShoppingCart = await _basketRepository.UpdateBasket(new ShoppingCart()
            {

                UserName = request.UserName,
                items = request.items
            });
            var shoppingCartResponse = _mapper.Map<ShoppingCartResponse>(CreateShoppingCart);
            return shoppingCartResponse;
        }
    }
}
