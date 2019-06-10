using NorthWindAzure2.GenericClasses;
using NorthWindAzure2.Interfaces;

namespace NorthWindAzure2
{
    public partial class Customer : Entity<int>
    {
        public int Id => CustomerIdentifier;
    }
}
