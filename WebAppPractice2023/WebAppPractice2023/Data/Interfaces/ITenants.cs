using System.Collections.Generic;
using WebAppPractice2023.Data.Models;

namespace WebAppPractice2023.Data.Interfaces
{
    public interface ITenants
    {
        IEnumerable<Tenants> Tenant { get; set; }
        IEnumerable<Tenants> GetAllTenants { get; }
        Tenants GetTenants(int tenantId);
    }
}
