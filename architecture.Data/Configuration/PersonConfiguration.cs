using architecture.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace architecture.Data.Configuration
{
   public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
       public PersonConfiguration()
       {
           Property(x => x.ID).HasColumnName(@"PId").IsRequired().HasColumnType("bigint");
           Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(300);
           Property(x => x.Age).IsRequired();
           Property(x => x.dateOfBirth).IsRequired();
       }
    }
}
