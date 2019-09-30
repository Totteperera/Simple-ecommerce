using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleEcommerce.DAL.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get { return OrderRows != null ? OrderRows.Sum(x => x.Quantity * x.Product.Price) : 0; } }

        public virtual ICollection<OrderRow> OrderRows { get; set; }
    }
}
