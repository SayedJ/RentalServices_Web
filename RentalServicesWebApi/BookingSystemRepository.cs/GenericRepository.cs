using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _entities;
        internal DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(DbContext context, ILogger logger)
        {
            _logger = logger;
            _entities = context;
            this.dbSet = context.Set<T>();
        }

        public virtual async Task<T> Get(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Remove(int id)
        {
            throw new NotImplementedException();


            
        }


        public virtual async Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetByName(string name)
        {
            throw new NotImplementedException();
        }


        public virtual Task<IEnumerable<T>> FindByName(string name)
        {
            throw new NotImplementedException();
        }

       
    }
}
