using System.Data.Entity.ModelConfiguration;
using Homes.Model;

namespace Homes.DataAccess.Configuration
{
    public class OAuthMembershipConfiguration : EntityTypeConfiguration<OAuthMembership>
    {
        public OAuthMembershipConfiguration()
        {
            this.ToTable("Webpages_OAuthMembership");
            this.HasKey(o => new { o.Provider, o.ProviderUserId });
            this.Property(o => o.ProviderUserId).IsRequired().HasMaxLength(100);
            this.Property(o => o.Provider).IsRequired().HasMaxLength(30);
            this.Property(o => o.UserId).IsRequired();
        }
    }
}