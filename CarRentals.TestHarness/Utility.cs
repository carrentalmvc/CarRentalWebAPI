using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rennish.TestHarness
{
   public class Utility
    {
       public static string Reverse(string input)
       {
           char[] cArray = input.ToCharArray();
           string reverse = String.Empty;
           for (int i = cArray.Length - 1; i > -1; i--)
           {
               reverse += cArray[i];
           }
           return reverse;
       }
    }
}
