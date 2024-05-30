using AddressBook.Data.Contexts;
using AddressBook.Domain.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AddressBook.Data.Reposatories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AddressBookDbContext _context;
        private readonly IMapper _mapper;

        public GenericRepository(AddressBookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TResult> GetAsync<TResult>(Expression<Func<T, bool>> filter, params string[] properties)
        {
            IQueryable<T> query = _context.Set<T>().Where(filter);
            if (properties is not null)
            {
                foreach (var property in properties)
                {
                    query = query.Include(property);
                }
            }
            return await query.ProjectTo<TResult>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
        public async Task<List<TResult>> GetAllAsync<TResult>(int pageNmuber, int pageSize, Expression<Func<T, bool>?> filter = null, Expression<Func<T, object>?> order = null, Expression<Func<T, object>?> orderDesc = null, params string[] properties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            if (properties is not null)
            {
                foreach (var property in properties)
                {
                    query = query.Include(property);
                }
            }
            if (order is not null)
            {
                query = query.OrderBy(order);
            }
            if (orderDesc is not null)
            {
                query = query.OrderByDescending(orderDesc);
            }
            query = query.Skip(pageSize * (pageSize - 1)).Take(pageSize);
            return await query.ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, bool>?> filter = null, params string[] properties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter is not null)
            {
                query = query.Where(filter);
            }
            if (properties is not null)
            {
                foreach (var property in properties)
                {
                    query = query.Include(property);
                }
            }
            return await query.ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<bool> Exists(Expression<Func<T, bool>> filter)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(filter);
            return result is null ? false : true;
        }
        public async Task<int> GetCountAsync(Expression<Func<T, bool>?> filter)
        {
            IQueryable<T> query = _context.Set<T>();
            if(filter is not null)
            {
                query = query.Where(filter);
            }
         return  await query.CountAsync();
        }
        public void Add(T entity)
        {
          _context.Entry(entity).State=EntityState.Added;
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State= EntityState.Deleted;
        }






    }
}
