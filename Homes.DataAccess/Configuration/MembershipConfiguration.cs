using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homes.Model;

namespace Homes.DataAccess.Configuration
{
   public  class MembershipConfiguration : EntityTypeConfiguration<Membership>
    {
       public MembershipConfiguration()
       {
           this.ToTable("webpages_Membership");
           this.HasKey(m => m.UserId);
           this.Property(m => m.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
       }
    }
}
