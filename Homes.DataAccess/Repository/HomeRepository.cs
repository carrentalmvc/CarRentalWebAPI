using System.Linq;
using Homes.Model;

namespace Homes.DataAccess.Repository
{
    public class HomeRepository : GenericRepository<Home>
    {
        public HomeRepository(IDbContext cxt)
            : base(cxt)
        {

        }
        public override IQueryable<Home> GetAll()
        {
            var key = "Home_Entity_Cache_Key";
            var data = new CodedHomesCaching<Home>().GetDataFromCache(key);

            return data.AsQueryable<Home>();
        }

        private void ArrangeCachingSetup()
        {
        }
    }
}