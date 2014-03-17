using System.Data.Entity.ModelConfiguration;
using Homes.Model;

namespace Homes.DataAccess.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(u => u.UserName).IsRequired().HasMaxLength(200);
            this.Property(u => u.FirstName).IsRequired().HasMaxLength(200);
            this.Property(u => u.LastName).IsRequired().HasMaxLength(200);
            this.Property(u => u.CreatedOn).IsRequired().HasColumnType("DateTime");
            this.Property(u => u.ModifiedOn).IsOptional().HasColumnType("DateTime");
            //This is how we map many to many relation in EF.This will create the join table with the relationship,in the database
            this.HasMany(a => a.Roles)
                .WithMany(b => b.Users)
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                    m.ToTable("Webpages_UsersInRoles");
                });
        }
    }
}