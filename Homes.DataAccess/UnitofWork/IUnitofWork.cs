using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homes.DataAccess.UnitofWork
{
   public  interface IUnitofWork
    {

       void Commit();
    }
}
