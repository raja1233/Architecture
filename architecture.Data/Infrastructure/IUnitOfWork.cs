using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace architecture.Data.Infrastructure
{
   public interface IUnitOfWork
    {
       void Commit();
    }
}
