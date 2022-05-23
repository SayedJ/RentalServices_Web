using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RentalServicesWebApi.Context;
using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly RentalContext _userContext;

        public UserRepository(DbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(UserRepository));
                return new List<User>();
            }
        }

        public Task<IEnumerable<User>> Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> Update(User entity)
        {
            try
            {
                var existingUser = await  dbSet.Where(x => x.Id == entity.Id)
                    .FirstOrDefaultAsync();
                if (existingUser != null)
                    return await Add(entity);
                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.Email = entity.Email;
                existingUser.MobileNo = entity.MobileNo;
                existingUser.Password = entity.Password;

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(UserRepository));
                return false;
            }
            
        }

        public override async Task<bool> Remove(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if(exist == null ) return false;
                dbSet.Remove(exist);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Delete function error", typeof(UserRepository));
                return false;
            }
            
        }
    }
}
  
