using System.Linq.Expressions;

namespace RentalServicesWebApi.Repository
{
    public interface IGenericRepository<T>  where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Remove(int id);
        Task<IEnumerable<T>> FindByName(string name);


    }
}
