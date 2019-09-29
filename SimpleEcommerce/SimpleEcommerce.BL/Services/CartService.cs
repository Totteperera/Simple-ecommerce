using SimpleEcommerce.DAL;
using SimpleEcommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.BL.Services
{
    public class CartService
    {
        public Cart Get(Guid id)
        {
            using(var db = new SimpleEcommerceContext())
            {
                return db.Carts.FirstOrDefault(x => x.SessionId.Equals(id));
            }
        }

        public void Create(Cart cart)
        {
            using (var db = new SimpleEcommerceContext())
            {
                db.Carts.Add(cart);
                db.SaveChanges();
            }
        }
    }
}
