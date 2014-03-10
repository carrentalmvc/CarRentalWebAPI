namespace Homes.Model
{
    public class OAuthMembership
    {
        public string Provider { get; set; }

        public string ProviderUserId { get; set; }

        public int UserId { get; set; }
    }
}