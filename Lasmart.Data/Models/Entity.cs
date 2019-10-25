﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lasmart.Data.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", GetType().Name, Id);
        }
    }
}
