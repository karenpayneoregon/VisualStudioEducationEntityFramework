using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWindAzure2.Repositories;

namespace NorthWindAzure2.Operations
{
    public class DemoCustomers
    {
        public Customer GetCompanyByCustomerIdentifier(int pIdentifier)
        {
            using (var context = new NorthWindEntities())
            {
                var repository = new CustomerRepository(context);
                return repository.GetById(pIdentifier);
            }
        }
    }
}
