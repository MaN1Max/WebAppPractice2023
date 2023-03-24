using ClassLibrary;
using System.Linq;
using System;
using System.Collections.Generic;

namespace WebAPI.Repository
{
    public interface ITenantApiRepository
    {
        public List<Tenant> GetTenants();

        public Tenant GetTenantById(Guid id);

        public List<Tenant> GetTenantBySurn(string searchSurn);

        public Guid CreateTenant(Tenant entity);

        public Guid EditTenant(Tenant entity);

        public void DeleteTenant(Tenant entity);
    }
}
