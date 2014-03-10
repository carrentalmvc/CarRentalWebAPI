using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Homes.DataAccess.Repository
{
   public interface IRepository<T> where T : class
    {
       void Add(T entity);
       void Delete(T entity);
       void Delete(int Id);
       void Update(T entity);
       void Detach(T entity);
       IQueryable<T> GetAll();
       T GetById(int Id);
    }
}
