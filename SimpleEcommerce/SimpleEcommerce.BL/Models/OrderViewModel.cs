using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.BL.Models
{
    public class OrderViewModel
    {
        public decimal TotalPrice { get; set; }
        public IList<OrderRowViewModel> OrderRows { get; set; }
    }
}
