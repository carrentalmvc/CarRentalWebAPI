using System.Data.Entity;
using Homes.Model;

namespace Homes.DataAccess.Configuration
{
    public class CustomDatabaseInitializer : CreateDatabaseIfNotExists<HomesDataContext>
    {
        
        protected override void Seed(HomesDataContext context)
        {
            string[] descriptions = new string[10]{
              "Really Nice Neighborhood",
              "Nice school district",
              "Close to downtown",
              "Posh area in town",
              "Close to LA fitness and Bailys Gymn",
              "Hospitals are all around this neighborhood",
              "Laidback atmosphere",
              "Really cheap homes in here",
              "Diverse neighborhood" ,
              "Nice waterfront and close to beaches"
           };

            var counter = 0;
            while ((counter < descriptions.Length))
            {
                var home = new Home
                {
                    Id = counter == 0 ? 1 : counter,
                    BedRooms = 2,
                    Description = descriptions[counter],
                    ImageName = "Image " + counter,
                    NoOfBathrooms = 2,
                    Price = 200000.00M,
                    SquareFeet = 1200,
                    StreetAddress1 = "123 Mainstreet",
                    ZipCode = "32225"
                };
                context.Homes.Add(home);
                counter++;
            }
            base.Seed(context);
        }
    }
}