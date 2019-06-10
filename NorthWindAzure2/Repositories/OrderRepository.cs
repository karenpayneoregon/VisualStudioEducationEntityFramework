using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWindAzure2.GenericClasses;
using NorthWindAzure2.Interfaces;

namespace NorthWindAzure2.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context) { }
        public override IEnumerable<Order> GetAll()
        {
            return Entities.Set<Order>().Include(order => order.OrderDetails).AsEnumerable();
        }
        public Order GetById(int id)
        {
            
            return Dbset.Include(order => order.OrderDetails)
                .FirstOrDefault(order => order.OrderID == id);
        }
    }
}
