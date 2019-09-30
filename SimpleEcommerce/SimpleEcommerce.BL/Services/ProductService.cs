using SimpleEcommerce.BL.Mappers;
using SimpleEcommerce.BL.Models;
using SimpleEcommerce.DAL;
using SimpleEcommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.BL.Services
{
    public class ProductService
    {
        public Product Get(int id)
        {
            using(var db = new SimpleEcommerceContext())
            {
                return db.Products.FirstOrDefault(x => x.ID.Equals(id));
            }
        }

        public List<ProductViewModel> GetAll()
        {
            using (var db = new SimpleEcommerceContext())
            {
                var products = db.Products.ToList();
                return products.Select(x => x.Map()).ToList();
            }
        }
    }
}
