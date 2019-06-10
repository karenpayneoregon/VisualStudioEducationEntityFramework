using NorthWindAzure2.GenericClasses;

namespace NorthWindAzure2.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer GetById(int id);
    }
}
