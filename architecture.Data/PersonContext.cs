using architecture.Data.Configuration;
using architecture.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace architecture.Data
{
    public class PersonContext:DbContext
    {
        public PersonContext():base("ArchitectureData")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonConfiguration());
        }
        public DbSet<Person> person { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
