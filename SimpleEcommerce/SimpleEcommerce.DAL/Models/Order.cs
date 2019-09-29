using System;
using System.Collections.Generic;

namespace SimpleEcommerce.DAL.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; }
    }
}
