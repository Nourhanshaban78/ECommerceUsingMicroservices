using AutoMapper;
using Basket.Application.Commands;
using Basket.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Handler.Commands
{
    public class DeleteShoopingCartCommandHandler : IRequestHandler<DeleteShoppingCartCommand, Unit>
    {
        private readonly IBasketRepository _basketRepository;
        public DeleteShoopingCartCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task<Unit> Handle(DeleteShoppingCartCommand request, CancellationToken cancellationToken)
        {
            await _basketRepository.DeleteBasket(request.UserName);
            return Unit.Value;
        }
    }
}
