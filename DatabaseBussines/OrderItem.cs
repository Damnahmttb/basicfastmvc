using DatabaseConfiger;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBussines
{
    public class OrderItemBussines
    {
        DatabaseContext cotext;
        public OrderItemBussines(DatabaseContext context)
        {
            this.cotext = context;  
        }
        public List<OrderItem> Get()
        {
            return cotext.OrderItemTable.ToList();
        }
        public bool Update(OrderItem item)
        {
            OrderItem Orderitem= cotext.OrderItemTable.Find(item.Id);
            //Auto Mapper Kullanilabilir daha basit ve tassaruflu kilmak icin kullanmiyorum;
            Orderitem.ItemName = item.ItemName;
            Orderitem.Description = item.Description;
            Orderitem.Price=item.Price;
           EntityEntry entry= cotext.OrderItemTable.Update(Orderitem);
            if (entry.State==EntityState.Modified)
            {
                cotext.SaveChanges();
                return true;
            }
            return false;

        }
        public bool Add(OrderItem item)
        {
            EntityEntry entry = cotext.OrderItemTable.Add(item);
            if (entry.State == EntityState.Added)
            {
                cotext.SaveChanges();
                return true;
            }
            return false;

        }
        public bool Delete(int itemid)
        {
            var item=cotext.OrderItemTable.Find(itemid);
            EntityEntry entry = cotext.OrderItemTable.Remove(item);
            if (entry.State == EntityState.Deleted)
            {
                cotext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
