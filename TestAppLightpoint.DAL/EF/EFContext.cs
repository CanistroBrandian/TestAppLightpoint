using Microsoft.EntityFrameworkCore;
using TestAppLightpoint.DAL.Entities;

namespace TestAppLightpoint.DAL.EF
{
    public class EFContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }

        public EFContext(DbContextOptions<EFContext> options)
             : base(options)
        {
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().HasData(
                new Store()
                {
                    Id = 1,
                    Name = "Рублевский",
                    Address = "Ул. Смешная 14",
                    OpeningTimes = "08.00-22.00",
                },
                new Store()
                {
                    Id = 2,
                    Name = "Алми",
                    Address = "Ул. Грустная 15",
                    OpeningTimes = "08.00-22.00",
                },
                new Store()
                {
                    Id = 3,
                    Name = "Prostore",
                    Address = "Ул. Волшебства 18",
                    OpeningTimes = "08.00-22.00",
                });

            modelBuilder.Entity<Product>().HasData(new Product {Id=1, Name = "Колбаса", Description = "Для любителя пышных форм", StoreId = 1 },
                new Product { Id = 2, Name = "Грецкий орех", Description = "Полезный орех для ваших мозгов ", StoreId = 1 },
                new Product { Id = 3, Name = "Банан", Description = "Желтый и спелый", StoreId = 2 },
                new Product { Id = 4, Name = "Дыня", Description = "Желтый и не спелый", StoreId = 2 },
                new Product { Id = 5, Name = "Овсянка", Description = "Специальное предложение для зожников", StoreId = 3 },
                new Product { Id = 6, Name = "Пивко", Description = "Пивка для рывка", StoreId = 3 });
        }


    }
}
