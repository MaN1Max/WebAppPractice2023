using System.Linq;
using WebAppMVCPractice.Domain;
using WebAppMVCPractice.Models;

namespace WebAppMVCPractice.Repository
{
    public class TenantRepository
    {
        private readonly AppDbContext context;

        public TenantRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Tenant> GetTtenants() //получить всех
        {
            return context.Tenant.OrderBy(x => x.Surn);
        }

        public Tenant GetTenantById(int id) //получить по id
        {
            return context.Tenant.Single(x => x.Id == id);
        }

        public int SaveTenant(Tenant entity) //сохранение/обновление
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            context.SaveChanges();

            return entity.Id;
        }

        public void DeleteTenant(Tenant entity) //удаление
        {
            context.Tenant.Remove(entity);
            context.SaveChanges();
        }
    }
}
