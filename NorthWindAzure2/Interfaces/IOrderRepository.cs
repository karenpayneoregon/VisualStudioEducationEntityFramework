using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWindAzure2.GenericClasses;

namespace NorthWindAzure2.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Order GetById(int id);
    }
}
