using Basket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Domain.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string username);
        Task<ShoppingCart> UpdateBasket(ShoppingCart cart);
        Task DeleteBasket(string username);
    }
}
