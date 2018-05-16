using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace architecture.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _IdBFactory;
        private PersonContext dbContext;
        public UnitOfWork(IDbFactory IdbFactory)
        {
            this._IdBFactory = IdbFactory;
        }
        public PersonContext personContext
        {
            get { return dbContext ?? (dbContext = _IdBFactory.Init()); }
        }
        public void Commit()
        {
            personContext.Commit();
        }
    }
}
