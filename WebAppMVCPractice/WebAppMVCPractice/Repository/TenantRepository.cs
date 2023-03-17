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

        public IQueryable<Tenant> GetTenants()
        {
            return context.Tenant.OrderBy(x => x.Id);
        }

        public Tenant GetTenantById(int id)
        {
            return context.Tenant.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Tenant> GetTenantBySurn(string searchSurn)
        {
            return context.Tenant.Where(x => x.Surn.Contains(searchSurn));
        }

        public int CreateTenant(Tenant entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.SaveChanges();
            return entity.Id;
        }

        public int EditTenant(Tenant entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return entity.Id;
        }

        public void DeleteTenant(Tenant entity)
        {
            context.Tenant.Remove(entity);
            context.SaveChanges();
        }
    }
}
