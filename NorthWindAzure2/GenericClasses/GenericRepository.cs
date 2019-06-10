using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NorthWindAzure2.GenericClasses
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
          where T : BaseEntity
    {
        protected DbContext Entities;
        protected readonly IDbSet<T> Dbset;

        protected GenericRepository(DbContext context)
        {
            Entities = context;
            Dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll() => Dbset.AsEnumerable<T>();

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = Dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return Dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return Dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            Entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            Entities.SaveChanges();
        }
    }
}
