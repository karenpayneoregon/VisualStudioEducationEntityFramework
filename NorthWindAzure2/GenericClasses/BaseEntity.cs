using NorthWindAzure2.Interfaces;

namespace NorthWindAzure2.GenericClasses
{
    public abstract class BaseEntity
    {
    }
    public abstract class Entity<T> : BaseEntity //, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
