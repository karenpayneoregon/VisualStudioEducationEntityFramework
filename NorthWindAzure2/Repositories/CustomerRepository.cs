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
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context) { }
        public override IEnumerable<Customer> GetAll()
        {
            return Entities.Set<Customer>().Include(x => x.Country).AsEnumerable();
        }
        public Customer GetById(int id)
        {
            
            return Dbset.Include(customer => customer.Country)
                .FirstOrDefault(customer => customer.CustomerIdentifier == id);
        }
    }
  
}
