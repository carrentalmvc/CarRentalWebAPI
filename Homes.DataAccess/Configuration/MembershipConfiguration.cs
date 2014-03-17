using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Homes.Model;

namespace Homes.DataAccess.Configuration
{
    public class MembershipConfiguration : EntityTypeConfiguration<Membership>
    {
        public MembershipConfiguration()
        {
            this.ToTable("Webpages_Membership");
            this.HasKey(m => m.UserId);
            this.Property(m => m.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(m => m.ConfirmationToken).IsOptional().HasMaxLength(500);
            this.Property(m => m.IsConfirmed).IsOptional();
            this.Property(m => m.LastPasswordFailureDate).IsOptional().HasColumnType("datetime");
            this.Property(m => m.Password).IsRequired().HasMaxLength(200);
            this.Property(m => m.PasswordChangedDate).IsOptional().HasColumnType("datetime");
            this.Property(m => m.PasswordFailuresSinceLastSuccess).IsOptional();
            this.Property(m => m.PasswordSalt).IsRequired().HasMaxLength(200);
            this.Property(m => m.PasswordVerifiactionTokenExpirationDate).IsOptional();
            this.Property(m => m.PasswordVerificationToken).IsOptional().HasMaxLength(200);
        }
    }
}