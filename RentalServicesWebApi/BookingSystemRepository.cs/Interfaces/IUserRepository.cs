using System.Linq.Expressions;
using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> Get(int id);
        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<User>> Find(Expression<Func<User, bool>> predicate);
        Task<bool> Add(User entity);
        Task<bool> Update(User entity);
        Task<bool> Remove(int id);


    }
}
