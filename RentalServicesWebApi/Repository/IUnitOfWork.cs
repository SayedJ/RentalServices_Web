namespace RentalServicesWebApi.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository  Users {get; }
        IItemRepository Items {get; }

        ICategoryRepository Category {get; }
        Task CompleteAsync();
        void Dispose();
    }
}
