
using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentalServicesWebApi.Configuratioins.Entities;
using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Context
{
    public class RentalContext : IdentityDbContext<ApplicationUser>
    { 
        public RentalContext(DbContextOptions<RentalContext> options): base(options)
        {


        }


    
        public DbSet<Item> Items { get; set; }
        
        public DbSet<BookingSystem> BookingSystem { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RentalSetUp> RentalSetUps { get; set; }
        public DbSet<UploadedFiles> UploadedFiles { get; set; }
       
        public DbSet<Address> Addresses { get; set; }
       





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


           



            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 100, Name = "Electronic"},
                new Category {Id = 101, Name = "Home"}

            );
            modelBuilder.Entity<Item>().HasData(
             new Item { Id = 1, Name = "Laptop", Availability = Availability.Available,  Category_id= 100 , BoughtDate = DateTime.Now, Brand = "Samsung",  Description = "A laptop that has many feature to help you", ItemCondition = Condition.LikeNew, Price = 100 }
             );




            modelBuilder.Entity<Item>()
                .HasMany(i => i.BookingSystem)
                .WithOne(i => i.Item);

                

            modelBuilder.Entity<BookingSystem>()
                 .HasOne(i => i.Item)
                 .WithMany(i => i.BookingSystem);


            modelBuilder.Entity<BookingSystem>()
                .HasOne(i => i.RentingDateInfo)
                .WithOne(i => i.BookingSystem);


            modelBuilder.Entity<BookingSystem>()
               .HasOne(i => i.Address)
               .WithOne(s => s.Booking)
               .HasForeignKey<Address>(c => c.Booking_id);




            modelBuilder
           .Entity<BookingSystem>()
           .Property(e => e.Payment_Methods)
           .HasConversion(
               v => v.ToString(),
               v => (Payment)Enum.Parse(typeof(Payment), v));

            modelBuilder
           .Entity<BookingSystem>()
           .Property(e => e.Collecting)
           .HasConversion(
               v => v.ToString(),
               v => (Shipping)Enum.Parse(typeof(Shipping), v));

            modelBuilder
          .Entity<Item>()
          .Property(e => e.Availability)
          .HasConversion(
              v => v.ToString(),
              v => (Availability)Enum.Parse(typeof(Availability), v));
            modelBuilder
        .Entity<Item>()
        .Property(e => e.ItemCondition)
        .HasConversion(
            v => v.ToString(),
            v => (Condition)Enum.Parse(typeof(Condition), v));


            var decimalProps = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
       
    }
        
}
