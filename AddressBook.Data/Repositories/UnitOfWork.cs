using AddressBook.Data.Contexts;
using AddressBook.Domain.Contracts;
using AutoMapper;
using System.Collections;

namespace AddressBook.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AddressBookDbContext _context;
        private readonly IMapper _mapper;
        private Hashtable _repositories;

        public UnitOfWork(AddressBookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(type), _context, _mapper);
                _repositories[type.Name] = repositoryInstance;
            }
            return (IGenericRepository<TEntity>)_repositories[type.Name];
        }
    }
}
