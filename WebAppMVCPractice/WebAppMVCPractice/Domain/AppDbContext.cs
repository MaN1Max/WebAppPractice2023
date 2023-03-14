using Microsoft.EntityFrameworkCore;
using WebAppMVCPractice.Models;

namespace WebAppMVCPractice.Domain
{
    public class AppDbContext : DbContext //собственный контекст БД
    {
        public AppDbContext(DbContextOptions options) : base(options) { } //конструктор класса

        public DbSet<Tenant> Tenant { get; set; } //проекцируем класс на таблицу (контекст отслеживает состояние)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tenant>().HasData(new Tenant //тестовая забивка
            {
                Id = 1,
                Surn = "Иванов",
                Name = "Иван",
                Patr = "Иванович",
                Email = "te.st@gmail.com",
                Phone = "+12345678901"
            });
        }
    }
}
