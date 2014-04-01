using System;
using Homes.DataAccess;
using Homes.DataAccess.UnitofWork;
using Homes.Model;

namespace Rennish.TestHarness
{
    public class CodedHomes
    {
        public static void InitilazeCodedHomesDB()
        {
            Console.WriteLine("Started initilaizing the databse...");
            var cxt = new HomesDataContext();
            cxt.Database.Initialize(true);
            Console.WriteLine("Finished initializing the databse....");
            var uow = new UnitofWork(new HomesDataContext());
            var homes = uow.HomeRepository.GetAll();
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
        }
    }
}