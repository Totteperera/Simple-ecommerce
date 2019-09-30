using SimpleEcommerce.BL.Models;
using SimpleEcommerce.DAL.Models;

namespace SimpleEcommerce.BL.Mappers
{
    public static class OrderRowMapper
    {
        public static OrderRowViewModel Map(this OrderRow orderRow)
        {
            return new OrderRowViewModel
            {
                Product = orderRow.Product.Map(),
                Quantity = orderRow.Quantity
            };
        }
    }
}
