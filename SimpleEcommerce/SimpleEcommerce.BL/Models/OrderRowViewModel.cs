using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.BL.Models
{
    public class OrderRowViewModel
    {
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
    }
}
