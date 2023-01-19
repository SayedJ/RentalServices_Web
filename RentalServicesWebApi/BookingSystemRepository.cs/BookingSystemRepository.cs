using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Repository
{
    public class RentalInfoSystemRepository : GenericRepository<BookingSystem>, IRentalInfoSystemRepository
    {
        public RentalInfoSystemRepository(DbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<BookingSystem> Get(int id)
        {
            try
            {

                
                return await dbSet.Include(p => p.Item)
                    .ThenInclude(c => c.Category)
                    .FirstOrDefaultAsync(u => u.Id == id);
                

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(RentalInfoSystemRepository));
                return new BookingSystem();
            }
        }

        public override async Task<IEnumerable<BookingSystem>> GetAll()
        {
            try
            {
                return await dbSet.Include(p => p.Item)
                    .ThenInclude(c => c.Category)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(RentalInfoSystemRepository));
                return new List<BookingSystem>();

            }
        }

        public override async Task<bool> Update(BookingSystem entity)
        {
            try
            {
                var existItem = await dbSet.Where(x => x.Id == entity.Id)
                    .FirstOrDefaultAsync();
                if (existItem == null)
                    return await Add(entity);

                
                existItem.Rules = entity.Rules;
                existItem.PaymentRules = entity.PaymentRules;
                existItem.Payment_Methods = entity.Payment_Methods;
                
                existItem.TermsAccepted = entity.TermsAccepted;
                //existItem.Collecting = entity.Collecting;
                existItem.Item = entity.Item;
                existItem.RentingDateInfo = entity.RentingDateInfo;
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(RentalInfoSystemRepository));
                return false;
            }

        }

        public override async Task<bool> Remove(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (exist == null)
                    return false;

                dbSet.Remove(exist);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(RentalInfoSystemRepository));
                return false;
            }
        }


        public override async Task<IEnumerable<BookingSystem>> FindByName(string name)
        {
            try
            {
                return await dbSet.Include(p => p.Item)
                    .ThenInclude(c => c.Category)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(RentalInfoSystemRepository));
                return new List<BookingSystem>();

            }
        }

       
    }
}
