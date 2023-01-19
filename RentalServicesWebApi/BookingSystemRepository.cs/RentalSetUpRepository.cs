using Microsoft.EntityFrameworkCore;
using RentalServicesWebApi.Models;
using RentalServicesWebApi.Repository.Interfaces;

namespace RentalServicesWebApi.Repository
{
    public class RentalSetUpRepository : GenericRepository<RentalSetUp>, IRentalSetUpRepository
    {
        public RentalSetUpRepository(DbContext context, ILogger logger) : base(context, logger)
        {


        }
        public override async Task<RentalSetUp> Get(int id)
        {
            try
            {
                return await dbSet.FirstOrDefaultAsync(p => p.ResId == id);

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(RentalSetUpRepository));
                return new RentalSetUp();
            }
        }

        public override async Task<IEnumerable<RentalSetUp>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(RentalSetUpRepository));
                return new List<RentalSetUp>();

            }
        }

        public override async Task<bool> Update(RentalSetUp entity)
        {
            try
            {
                var existItem = await dbSet.Where(x => x.ResId== entity.ResId)
                    .FirstOrDefaultAsync();
                if (existItem == null)
                    return await Add(entity);

              
                existItem.BookingConfirmed = entity.BookingConfirmed;
                existItem.BookingStatus = entity.BookingStatus;
                existItem.FromDate = entity.FromDate;
                existItem.ToDate = entity.ToDate;
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(RentalSetUpRepository));
                return false;
            }

        }

        public override async Task<bool> Remove(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.ResId == id).FirstOrDefaultAsync();
                if (exist == null)
                    return false;

                dbSet.Remove(exist);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(RentalSetUpRepository));
                return false;
            }
        }


        public override async Task<IEnumerable<RentalSetUp>> FindByName(string name)
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(RentalSetUpRepository));
                return new List<RentalSetUp>();

            }
        }
    }
}
