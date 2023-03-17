using System.Linq;
using WebAppMVCPractice.Models;

namespace WebAppMVCPractice.Repository
{
    public interface ITenantRepository
    {
        public IQueryable<Tenant> GetTenants();

        public Tenant GetTenantById(int id);

        public IQueryable<Tenant> GetTenantBySurn(string searchSurn);

        public int CreateTenant(Tenant entity);

        public int EditTenant(Tenant entity);

        public void DeleteTenant(Tenant entity);
    }
}
