using SimpleEcommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.DAL.Mapper
{
    public static class CartToOrder
    {
        public static Order MapToOrder(this Cart cart)
        {
            return new Order
            {
                CreatedAt = DateTime.UtcNow,
                OrderRows = cart.OrderRows
            };
        }
    }
}
