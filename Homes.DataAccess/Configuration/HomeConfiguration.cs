using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Homes.Model;

namespace Homes.DataAccess.Configuration
{
    public class HomeConfiguration : EntityTypeConfiguration<Home>
    {
        public HomeConfiguration()
        {
            Property(h => h.BedRooms).IsOptional();
            Property(h => h.Description).HasMaxLength(200).IsOptional();
            Property(h => h.ImageName).HasMaxLength(200).IsOptional();
            Property(h => h.NoOfBathrooms).IsOptional();
            Property(h => h.Price).HasPrecision(10, 2).IsOptional();
            Property(h => h.StreetAddress1).IsRequired().HasMaxLength(200);
            Property(h => h.StreetAddress2).IsOptional().HasMaxLength(200);
            Property(h => h.CreatedOn).IsRequired().HasColumnType("DateTime");
            Property(h => h.ModifiedOn).IsOptional().HasColumnType("DateTime");
            Property(h => h.ZipCode).IsRequired().HasMaxLength(10);

        }
    }
}
