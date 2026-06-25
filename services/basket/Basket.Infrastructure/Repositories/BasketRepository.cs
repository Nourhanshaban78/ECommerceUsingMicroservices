using Basket.Domain.Entities;
using Basket.Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _cache;

        public BasketRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task DeleteBasket(string username)
        {
            var basket = await _cache.GetStringAsync(username);
            if (basket != null)
                await _cache.RemoveAsync(username);
           
        }
        public async Task<ShoppingCart> GetBasket(string username)
        {
            var basket = await _cache.GetStringAsync(username);
            if (string.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart cart)
        {
            var basket = await _cache.GetStringAsync(cart.UserName);
            if (basket != null)
            {
                return await GetBasket(cart.UserName);
            }
            else
            {
                await _cache.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));
                return await GetBasket(cart.UserName);

            }
        }
    }
}
