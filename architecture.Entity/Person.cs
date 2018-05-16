﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace architecture.Entity
{
    public class Person:IEntityBase
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime dateOfBirth { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

    }
}
