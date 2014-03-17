using System;
using Homes.DataAccess.Repository;
using Homes.Model;

namespace Homes.DataAccess.UnitofWork
{
    /// <summary>
    /// Unit of Work Pattern works with DatabaseContext and  Repositories
    /// The main idea of Uow is ,we can make changes to many repositories and save them all together while calling the SaveChanges()
    /// </summary>
    public class UnitofWork : IDisposable, IUnitofWork 
    {
        private HomesDataContext _cxt = null;
        private IRepository<Home> _home = null;
        private IRepository<User> _user = null;

        public UnitofWork(IDbContext cxt)
        {
            this._cxt = cxt as HomesDataContext;
            this._home = HomeRepository;
            this._user = UserRepository;
        }        

        public IRepository<Home> HomeRepository
        {
            get
            {
                if (_home == null)
                {
                    _home = new HomeRepository(this._cxt);
                }

                return _home;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (_user == null)
                {
                    _user = new GenericRepository<User>(this._cxt);
                }

                return _user;
            }
        }

        public void Commit()
        {
            _cxt.SaveChanges();
        }

        public void Dispose()
        {
            if (_cxt != null)
            {
                _cxt.Dispose();
            }
        }
    }
}