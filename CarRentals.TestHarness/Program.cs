using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homes.DataAccess;

namespace Rennish.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started initilaizing the databse...");
            var cxt = new HomesDataContext();
            cxt.Database.Initialize(true);
            Console.WriteLine("Finished initializing the databse....");

            Console.ReadLine();
            
        }
    }

    public class Person
    {

        public Person()
        {
            this.ObjectCreatedTime = DateTime.Now;
            if (_instance == null)
            { 
              
            }
        }

        private static  Person _instance = null;

        public DateTime ObjectCreatedTime { get; set; }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public static Person Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Person();
                }

                return _instance;
            }
        }
    }


}
