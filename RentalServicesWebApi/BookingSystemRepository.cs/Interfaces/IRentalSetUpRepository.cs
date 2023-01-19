using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Repository.Interfaces
{
    public interface IRentalSetUpRepository : IGenericRepository<RentalSetUp>
    {

        Task<RentalSetUp> Get(int id);
        Task<IEnumerable<RentalSetUp>> GetAll();
        Task<bool> Add(RentalSetUp entity);
        Task<bool> Update(RentalSetUp entity);
        Task<bool> Remove(int id);
    }

}