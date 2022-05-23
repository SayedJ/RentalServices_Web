using Microsoft.EntityFrameworkCore;
using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} all function error", typeof(CategoryRepository));
                return new List<Category>();
            }
        }

        public override async Task<bool> Update(Category category)
        {
            try
            {
                var existingCategory = await dbSet.Where(x => x.Id == category.Id).FirstOrDefaultAsync();
                if (existingCategory == null)
                    return await Add(category);

                existingCategory.Name = category.Name;
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} all function error", typeof(CategoryRepository));
                return false;
            }
        }

        public override async Task<bool> Remove(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} all function error", typeof(CategoryRepository));
                return false;
            }

            
        }
    }
}
