using System;

namespace Homes.Model
{
    public class Home : IAuditInfo
    {
        public int Id { get; set; }

        public string StreetAddress1 { get; set; }

        public string StreetAddress2 { get; set; }

        public string ZipCode { get; set; }

        public int? NoOfBathrooms { get; set; }

        public decimal Price { get; set; }

        public int? BedRooms { get; set; }

        public int SquareFeet { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public DateTime CreatedOn
        {
            get;
            set;
        }

        public DateTime ModifiedOn
        {
            get;
            set;
        }
    }
}