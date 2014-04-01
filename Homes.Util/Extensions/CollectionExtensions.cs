using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homes.Util.Extensions
{
   public static  class CollectionExtensions
    {
       public static bool IsNullOrEmpty<T>(this IEnumerable<T> coll)
       {
           return (coll == null || !coll.Any());
       }
    }
}
