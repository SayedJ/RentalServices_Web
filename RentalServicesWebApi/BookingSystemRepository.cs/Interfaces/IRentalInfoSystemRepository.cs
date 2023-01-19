using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Repository
{
    public interface IRentalInfoSystemRepository : IGenericRepository<BookingSystem>
    {
        Task<BookingSystem> Get(int id);
        Task<IEnumerable<BookingSystem>> GetAll();
        Task<bool> Add(BookingSystem entity);

        
        Task<bool> Update(BookingSystem entity);
        Task<bool> Remove(int id);
    }
}
