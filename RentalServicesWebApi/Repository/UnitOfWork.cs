using RentalServicesWebApi.Context;
using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentalContext _context;
        private readonly ILogger _logger;
        public IUserRepository Users { get; private set; }
        public IItemRepository Items { get; private set; }

        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(RentalContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Users = new UserRepository(context, _logger);
            Items = new ItemRepository(context, _logger);
            Category = new CategoryRepository(context, _logger);
        }

    
        

        public async Task CompleteAsync()
        {
          await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
