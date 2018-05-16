using architecture.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace architecture.Data.Repository
{
    public interface IEntityBaseRepository<T> where T :class, IEntityBase,new()
    {
        IQueryable<T> getAll();
        void Add(T p);
        void Delete(T entity);
        void SoftDelete(T entity);
        T GetSingle(long? id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> Predicate);
        void Edit(T oldEntity, T newEntity);
    }
}
