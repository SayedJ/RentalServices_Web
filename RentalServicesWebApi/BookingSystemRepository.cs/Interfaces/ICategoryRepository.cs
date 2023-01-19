using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> Get(int id);
        Task<IEnumerable<Category>> GetAll();
        Task<bool> Add(Category entity);
        Task<bool> Update(Category entity);
        Task<bool> Remove(int id);

    }
}
