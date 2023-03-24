using System;
using System.Linq;
using WebAPI.Domain;
using ClassLibrary;
using System.Collections.Generic;

namespace WebAPI.Repository
{
    public class TenantApiRepository : ITenantApiRepository
    {
        private readonly ApiDbContext context;

        public TenantApiRepository(ApiDbContext context)
        {
            this.context = context;
        }

        public List<Tenant> GetTenants()
        {
            return context.Tenant.OrderBy(x => x.Id).ToList();
        }

        public Tenant GetTenantById(Guid id)
        {
            return context.Tenant.SingleOrDefault(x => x.Id == id);
        }

        public List<Tenant> GetTenantBySurn(string searchSurn)
        {
            return context.Tenant.Where(x => x.Surn.Contains(searchSurn)).ToList();
        }

        public Guid CreateTenant(Tenant entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.SaveChanges();
            return entity.Id;
        }

        public Guid EditTenant(Tenant entity)
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
