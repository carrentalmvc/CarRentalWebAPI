using System;
using System.Collections.Generic;
using Homes.DataAccess;
using Homes.DataAccess.UnitofWork;
using Homes.Model;
using Homes.Util.Extensions;
namespace Rennish.TestHarness
{
    internal class Program
    {
        private static void Main(string[] args)
        {
           // CodedHomes.InitilazeCodedHomesDB();
            var coll = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = coll.IsNullOrEmpty<int>();
            Console.WriteLine("The collection is not null : {0}", result);

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

        private static Person _instance = null;

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

    public abstract class Employee
    {
        public string Name { get; set; }

        public abstract void Manage();

        public int Add(int x, int y)
        {
            return x + y;
        }
    }

    public class Manager : Employee
    {
        public Manager()
            : base()
        {
        }

        public override void Manage()
        {
            Console.WriteLine("My name is override manager..");
        }
    }
}