using SimpleEcommerce.BL.Models;
using SimpleEcommerce.DAL.Models;
using System.Linq;

namespace SimpleEcommerce.BL.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel Map(this Order order)
        {
            return new OrderViewModel
            {
                OrderRows = order.OrderRows.Select(x => x.Map()).ToList(),
                TotalPrice = order.TotalPrice
            };
        }
    }
}
