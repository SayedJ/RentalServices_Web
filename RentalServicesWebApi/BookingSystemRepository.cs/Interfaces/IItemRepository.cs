using System.Linq.Expressions;
using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Repository
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task<Item> Get(int id);
        Task<IEnumerable<Item>> GetAll();
        Task<bool> Add(Item entity);
        Task<bool> Update(Item entity);
        Task<bool> Remove(int id);
        Task<Item> GetByName(string name);
        Task<IEnumerable<Item>> FindByName(string name);
    }
}
