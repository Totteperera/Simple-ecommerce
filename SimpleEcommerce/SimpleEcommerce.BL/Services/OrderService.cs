using SimpleEcommerce.BL.Models;
using SimpleEcommerce.DAL;
using SimpleEcommerce.DAL.Models;
using SimpleEcommerce.BL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.BL.Services
{
    public class OrderService
    {
        public void PlaceOrder(Order order)
        {
            using(var db = new SimpleEcommerceContext())
            {
                order.CreatedAt = DateTime.Now;
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public Order Get(int id)
        {
            using (var db = new SimpleEcommerceContext())
            {
                return db.Orders.FirstOrDefault(x => x.ID == id);
            }
        }

        public OrderViewModel GetViewModel(int id)
        {
            using (var db = new SimpleEcommerceContext())
            {
                return db.Orders.FirstOrDefault(x => x.ID == id).Map();

            }
        }
    }
}
