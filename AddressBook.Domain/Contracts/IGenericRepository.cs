using System.Linq.Expressions;

namespace AddressBook.Domain.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<TResult> GetAsync<TResult>(Expression<Func<T, bool>> filter, params string[] properties);

        Task<List<TResult>> GetAllAsync<TResult>(int pageNmuber,
        int pageSize, Expression<Func<T, bool>?> filter = null, Expression<Func<T, object>?> order = null, Expression<Func<T, object>?> orderDesc = null, params Expression<Func<T, object>>[] properties);

        Task<T> FindById(int id);
        Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, bool>?> filter = null, params string[] properties);
        Task<int> GetCountAsync(Expression<Func<T, bool>?> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<bool> Exists(Expression<Func<T, bool>> filter);
    }
}
