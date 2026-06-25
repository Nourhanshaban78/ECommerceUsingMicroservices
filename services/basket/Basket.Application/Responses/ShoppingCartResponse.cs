using Basket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Responses
{
    public class ShoppingCartResponse
    {
        public ShoppingCartResponse(string userName)
        {
            UserName = userName;
        }
        public ShoppingCartResponse()
        {
            
        }

        public string UserName { get; set; }
        public List<ShoppingCartItem> items { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach(ShoppingCartItem item in items)
                {
                    total += item.Price * item.Quantity;
                }
                return total;
            }
        }
    }
}
