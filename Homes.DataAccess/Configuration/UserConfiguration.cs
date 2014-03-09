using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homes.Model;

namespace Homes.DataAccess.Configuration
{
   public class UserConfiguration : EntityTypeConfiguration<User>
    {

       public UserConfiguration()
       {
           Property(u => u.UserName).IsRequired().HasMaxLength(200);
           Property(u => u.FirstName).IsRequired().HasMaxLength(200);
           Property(u => u.LastName).IsRequired().HasMaxLength(200);
           Property(u => u.CreatedOn).IsRequired().HasColumnType("DateTime");
           Property(u => u.ModifiedOn).IsOptional().HasColumnType("DateTime");
       }
    }
}
