using Basket.Application.Responses;
using Basket.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Commands
{
    public class UpdateShoppingCartCommand :IRequest<ShoppingCartResponse>
    {
        public UpdateShoppingCartCommand(string userName, List<ShoppingCartItem> items)
        {
            UserName = userName;
            this.items = items;
        }

        public string UserName { get; set; }
        public List<ShoppingCartItem> items { get; set; }
    }
}
