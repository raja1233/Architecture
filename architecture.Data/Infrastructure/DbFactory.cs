using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace architecture.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        PersonContext dbContext;

        public PersonContext Init()
        {
            return dbContext ?? (dbContext = new PersonContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
