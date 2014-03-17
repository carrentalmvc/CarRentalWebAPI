using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homes.Model;

namespace Homes.DataAccess.Configuration
{
    public class RolesConfiguration : EntityTypeConfiguration<Role>
    {
        public RolesConfiguration()
        {
            this.ToTable("Webpages_Roles");
            this.HasKey(r => r.RoleId);
            this.Property(r => r.RoleName).IsRequired().HasMaxLength(15);
        }
    }
}
