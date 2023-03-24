using Microsoft.EntityFrameworkCore;
using System;
using ClassLibrary;

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
                Id = Guid.NewGuid(),
                Surn = "Иванов",
                Name = "Иван",
                Patr = "Иванович",
                Email = "te.st@gmail.com",
                Phone = "123456"
            });
        }
    }
}
