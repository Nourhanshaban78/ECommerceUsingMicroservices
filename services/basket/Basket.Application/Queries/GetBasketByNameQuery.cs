using Basket.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Queries
{
    public class GetBasketByNameQuery :IRequest<ShoppingCartResponse>
    {
        public GetBasketByNameQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }

    }
}
