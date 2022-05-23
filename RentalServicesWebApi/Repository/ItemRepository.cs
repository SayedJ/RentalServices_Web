using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RentalServicesWebApi.Context;
using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Repository
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
       

        public ItemRepository(RentalContext context, ILogger logger) : base(context, logger)
        {
       

        }

        public override async Task<Item> Get(int id)
        {
            try
            {
                return await dbSet.Include(p => p.Category).FirstOrDefaultAsync(d => d.Id == id);
       
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(ItemRepository));
                return new Item();
            }
          

        }

        public override async Task<IEnumerable<Item>> GetAll()
        {
            try
            {
                return await dbSet.Include(c => c.Category).ToListAsync();
            }
            catch (Exception e)
            {
               _logger.LogError(e, "{Repo} All function error", typeof(ItemRepository));
               return new List<Item>();
            }
        }

        public override async Task<bool> Update(Item item)
        {
            try
            {
                var existItem = await dbSet.Where(x => x.Id == item.Id)
                    .FirstOrDefaultAsync();
                if (existItem == null)
                    return await Add(item);
                
                existItem.Name = item.Name;
                existItem.Category = item.Category;
                existItem.Price = item.Price;
                existItem.ImagePath = item.ImagePath;
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(ItemRepository));
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
                _logger.LogError(e, "{Repo} All function error", typeof(ItemRepository));
                return false;
            }
        }

       
    }
}
