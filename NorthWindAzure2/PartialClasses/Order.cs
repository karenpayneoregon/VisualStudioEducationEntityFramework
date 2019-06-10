using NorthWindAzure2.GenericClasses;
using NorthWindAzure2.Interfaces;

namespace NorthWindAzure2
{
    public partial class Order : Entity<int>
    {
        public int Id => OrderID;
    }
}
