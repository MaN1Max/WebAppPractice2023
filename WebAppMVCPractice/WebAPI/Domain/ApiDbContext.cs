using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Domain
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Tenant> Tenant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tenant>().HasData(new Tenant
            {
                Id = 1,
                Surn = "Иванов",
                Name = "Иван",
                Patr = "Иванович",
                Email = "te.st@gmail.com",
                Phone = "12345678901"
            });
        }
    }
}
