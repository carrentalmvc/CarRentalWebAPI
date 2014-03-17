using System;
using Homes.DataAccess;
using Homes.DataAccess.UnitofWork;
using Homes.Model;

namespace Rennish.TestHarness
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Started initilaizing the databse...");
            var cxt = new HomesDataContext();
            cxt.Database.Initialize(true);
            Console.WriteLine("Finished initializing the databse....");
            var uow = new UnitofWork(new HomesDataContext());
            var homes =  uow.HomeRepository.GetAll();
            Console.WriteLine("First call made to the Home Repo....");
            uow.HomeRepository.Add(new Home
            {
                Id = 11,
                ImageName = "Candlebakkimgae.jpg",
                BedRooms = 4,
                Description = "This is the sweet home in Jackosnville",
                Price = 214500.00M,
                StreetAddress1 = "1068 Candlebar Dr",
                ZipCode = "32204"

            });

            uow.Commit();

            foreach (var home in homes)
            {
                Console.WriteLine(string.Format("Home details are {0} {1} {2}", home.Price, home.SquareFeet, home.ZipCode));
            }
            var homes2 = uow.HomeRepository.GetAll();

            foreach (var home in homes2)
            {
                Console.WriteLine("Home Address {0} ", home.StreetAddress1);
            }

            Console.WriteLine("Second call made to the Home Repo....");

            

            

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
        public Manager() : base()
        {

        }


        public override void Manage()
        {
            Console.WriteLine("My name is override manager..");
        }
    }
}