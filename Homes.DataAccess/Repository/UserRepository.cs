using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homes.Model;

namespace Homes.DataAccess.Repository
{
   public  class UserRepository : GenericRepository<User>
    {
       public UserRepository(HomesDataContext cxt) : base(cxt)
       {

       }
    }
}
