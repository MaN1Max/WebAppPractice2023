using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ClassLibrary;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantApiController : ControllerBase
    {
        private readonly ITenantApiRepository tenantApiRepository;

        public TenantApiController(ITenantApiRepository tenantApiRepository)
        {
            this.tenantApiRepository = tenantApiRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = tenantApiRepository.GetTenants();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBySurn(string surn)
        {
            var model = tenantApiRepository.GetTenantBySurn(surn);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tenant model)
        {
            tenantApiRepository.CreateTenant(model);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Tenant model)
        {
            tenantApiRepository.EditTenant(model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            tenantApiRepository.DeleteTenant(new Tenant() { Id = id });
            return Ok(id);
        }
    }
}
