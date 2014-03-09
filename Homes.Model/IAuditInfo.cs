﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homes.Model
{
   public interface IAuditInfo
    {
       DateTime CreatedOn { get; set; }

       DateTime ModifiedOn { get; set; }
    }
}
