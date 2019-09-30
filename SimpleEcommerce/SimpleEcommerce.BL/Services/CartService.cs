using SimpleEcommerce.BL.Mappers;
using SimpleEcommerce.BL.Models.Cart;
using SimpleEcommerce.DAL;
using SimpleEcommerce.DAL.Mapper;
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

        public CartViewModel GetViewModel(Guid id)
        {
            using (var db = new SimpleEcommerceContext())
            {
                return db.Carts.FirstOrDefault(x => x.SessionId.Equals(id)).Map();
            }
        }

        public void Clear(Guid id)
        {
            using (var db = new SimpleEcommerceContext())
            {
                var cart = db.Carts.FirstOrDefault(x => x.SessionId.Equals(id));

                foreach (var orderRow in db.OrderRows.Where(x => x.CartID == cart.ID))
                {
                    orderRow.CartID = null;
                }

                db.SaveChanges();
            }
        }

        public Order CreateOrderModelFromCart(Guid id)
        {
            using (var db = new SimpleEcommerceContext())
            {
                return db.Carts.FirstOrDefault(x => x.SessionId.Equals(id)).MapToOrder();
            }
        }
    }
}
