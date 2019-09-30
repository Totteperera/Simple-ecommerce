using SimpleEcommerce.DAL;
using SimpleEcommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.BL.Services
{
    public class OrderRowService
    {
        public void Create(OrderRow orderRow)
        {
            using(var db = new SimpleEcommerceContext())
            {
                db.OrderRows.Add(orderRow);
                db.SaveChanges();
            }
        }

        public void AddOne(OrderRow orderRow)
        {
            using (var db = new SimpleEcommerceContext())
            {
                var orderRowPersisted = db.OrderRows.FirstOrDefault(x => x.ID.Equals(orderRow.ID));
                orderRowPersisted.Quantity++;
                db.SaveChanges();
            }
        }

        public IList<OrderRow> GetFromCartId(int id)
        {
            using (var db = new SimpleEcommerceContext())
            {
                return db.OrderRows.Where(x => x.CartID.Value.Equals(id)).ToList();
            }
        }
    }
}
