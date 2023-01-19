

namespace RentalServicesWebApi.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        
        IItemRepository Items {get; }
        IRentalInfoSystemRepository RentalSystem { get; }
        ICategoryRepository Category {get; }
       
        Task CompleteAsync();
        void Dispose();
    }
}
