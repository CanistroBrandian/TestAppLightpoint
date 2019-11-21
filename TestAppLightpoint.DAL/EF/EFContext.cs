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


    }
}
