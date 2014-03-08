using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentals.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj1 = Person.Instance;

            var ctrObj = new Person();
            if (object.ReferenceEquals(obj1, ctrObj))
            {
                Console.WriteLine("Objects are equal");
            }

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
