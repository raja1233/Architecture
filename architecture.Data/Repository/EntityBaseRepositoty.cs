using architecture.Data.Infrastructure;
using architecture.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace architecture.Data.Repository
{
    public  class EntityBaseRepositoty <T>: IEntityBaseRepository<T>  where T : class ,IEntityBase, new()
    {
        private PersonContext db;

        #region Properties
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

         protected PersonContext DbContext
        {
            get { return db ?? (db = DbFactory.Init()); }
        }
         public  EntityBaseRepositoty(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
        #endregion
        public virtual IQueryable<T> getAll()
        {
            return DbContext.Set<T>().Where(x => x.IsDeleted == false);
            
        }
        //delete record from database

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityDelete = DbContext.Entry<T>(entity);
            dbEntityDelete.State = EntityState.Deleted;
        }
        public virtual void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            DbEntityEntry dbEntityDelete = DbContext.Entry<T>(entity);
            dbEntityDelete.State = EntityState.Modified;
        }



        public T GetSingle(long? id)
        {
            return getAll().FirstOrDefault(x => x.ID == id);
        }
        //this is for expression tree, with this you may code the lamda expression and complex query
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate).Where(x => x.IsDeleted == false);
        }
        public virtual IQueryable<T> All
        {
            get
            {
                return getAll();
            }
        }
        public void Add(T p)
        {
            p.IsDeleted = false;
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(p);
            DbContext.Set<T>().Add(p);
        }
        public virtual void Edit(T oldEntity, T newEntity)
        {
            DbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }
    }
}
