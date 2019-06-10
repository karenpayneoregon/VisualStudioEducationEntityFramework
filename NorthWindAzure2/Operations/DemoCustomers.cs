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
            var customer = new Customer();

            using (var context = new NorthWindEntities())
            {
                customer =context.Customers.FirstOrDefault(cust => cust.CustomerIdentifier == pIdentifier);
            }

            using (var context = new NorthWindEntities())
            {
                var repository = new CustomerRepository(context);
                var test = repository.GetById(pIdentifier);
            }


            return customer;
        }
    }
}
