using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace WebAppMVCPractice.Repository
{
    public interface ITestRepository
    {
        public List<Tenant> GetTenants();

        public List<Tenant> GetTenantBySurn(string surn);

        public HttpResponseMessage CreateTenant(Tenant entity);

        public Tenant EditTenant(Guid id);

        public HttpResponseMessage EditTenantPost(Tenant entity);

        public HttpResponseMessage DeleteTenant(Guid id);
    }
}
