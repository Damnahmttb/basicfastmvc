using DatabaseConfiger;
using Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DatabaseBussines
{
    public class OrderBussines
    {
        DatabaseContext context;
        public OrderBussines(DatabaseContext context)
        {
            this.context = context;
        }
        public List<Order> Get() 
        {
           return context.OrderTable.ToList();
        }
        public bool Update(Order order) 
        {
            Order neworder = context.OrderTable.Find(order.Id);
            neworder.Address= order.Address;
            EntityEntry entry = context.OrderTable.Update(neworder);

            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Add(Order order)
        {
            EntityEntry entry = context.OrderTable.Add(order);
            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int  orderid) 
        {
            var order=context.OrderTable.Find(orderid);
            EntityEntry entry=context.OrderTable.Remove(order);
            if (entry.State==Microsoft.EntityFrameworkCore.EntityState.Deleted)
            {
                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
