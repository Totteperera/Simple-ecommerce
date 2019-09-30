using SimpleEcommerce.BL.Models.Cart;
using SimpleEcommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.BL.Mappers
{
    public static class CartMapper
    {
        public static CartViewModel Map(this Cart cart)
        {
            return new CartViewModel
            {
                NumberOfRows = cart?.OrderRows.Count() ?? 0,
                TotalPrice = cart?.TotalPrice ?? 0
            };
        }
    }
}
