using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Domain.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> items { get; set; } = new List<ShoppingCartItem>();   
        public ShoppingCart() { }

        public ShoppingCart(string username)
        {
            UserName = username;
        }
    }
}
