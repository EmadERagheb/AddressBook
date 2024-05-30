using AddressBook.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Reposatories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public GenericRepository()
        {
            
        }
        public Task<TResult> GetAsync<TResult>(Expression<Func<T, bool>> filter, params string[] properties)
        {
            throw new NotImplementedException();
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> GetAllAsync<TResult>(int pageNmuber, int pageSize, Expression<Func<T, bool>?> filter = null, Expression<Func<T, object>?> order = null, Expression<Func<T, object>?> orderDesc = null, params string[] properties)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, bool>> filter, params string[] properties)
        {
            throw new NotImplementedException();
        }


        public Task<int> GetCountAsync(Expression<Func<T, bool>?> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
