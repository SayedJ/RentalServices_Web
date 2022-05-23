using Microsoft.EntityFrameworkCore;
using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Context
{
    public class RentalContext : DbContext
    {
        public RentalContext(DbContextOptions<RentalContext> options): base (options)
        {

            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CollectingMethod> CollectingMethods { get; set; }
        public DbSet<RentalInfoSystem> RentalInfoSystems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RentalSetUp> RentalSetUps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().HasMany(x => x.Category);
        }
       
    }
}
