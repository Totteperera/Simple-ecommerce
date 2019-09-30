using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.BL.Models.Cart
{
    public class CartViewModel
    {
        public decimal TotalPrice { get; set; }
        public int NumberOfRows { get; set; }
    }
}
