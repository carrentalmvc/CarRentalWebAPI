using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homes.DataAccess.Repository
{
    /// <summary>
    /// Each Repository works with its own version of DBSet and DbContext
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class GenericRepository<T> : IRepository<T> where T : class
    {
       protected DbSet<T> DBSet { get; set; }

       protected HomesDataContext DbContext { get; set; }

       //To DO: get rid of the tight coupling in the constructor and add a dependency injection
       public GenericRepository(IDbContext cxt)
       {
           if (cxt == null)
           {
               throw new ArgumentException("Repository needs to pass in a Datacontext");
           }

           else
           {
               this.DbContext = cxt as HomesDataContext;
               this.DBSet = this.DbContext.Set<T>();
           }
       }

        public void Add(T entity)
        {
           var entry =  this.DbContext.Entry(entity);
           if (entry.State != EntityState.Detached)
           {
               entry.State = EntityState.Added;
           }
           else
           {
               this.DBSet.Add(entity);
           }          
           
        }

        public void Delete(T entity)
        {
            var entry = this.DbContext.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DBSet.Attach(entity);
                this.DBSet.Remove(entity);
            }
        }

        public void Delete(int Id)
        {
            var entity = this.GetById(Id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Update(T entity)
        {
            var entry = this.DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DBSet.Attach(entity);
            }
            entry.State = EntityState.Modified;

        }

        public virtual IQueryable<T> GetAll()
        {
            return this.DBSet;
        }

        public T GetById(int Id)
        {
            return this.DBSet.Find(Id);
        }


        public void Detach(T entity)
        {
            var entry = this.DbContext.Entry(entity);
            entry.State = EntityState.Detached;
        }
    }
}
