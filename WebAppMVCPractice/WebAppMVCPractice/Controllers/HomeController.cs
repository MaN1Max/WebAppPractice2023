using Microsoft.AspNetCore.Mvc;
using WebAppMVCPractice.Models;
using WebAppMVCPractice.Repository;

namespace WebAppMVCPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly TenantRepository tenantRepository;

        public HomeController(TenantRepository tenantRepository)
        {
            this.tenantRepository = tenantRepository;
        }

        public IActionResult TenantList()
        {
            var model = tenantRepository.GetTenants();
            return View(model);
        }

        public IActionResult TenantBySurn(string surn)
        {
            var model = tenantRepository.GetTenantBySurn(surn);
            return View(model);
        }

        public IActionResult TenantCreate()
        {
            Tenant model = new Tenant();
            return View(model);
        }

        [HttpPost]
        public IActionResult TenantCreate(Tenant model)
        {
            if (ModelState.IsValid)
            {
                tenantRepository.CreateTenant(model);
                return RedirectToAction("TenantList");
            }
            return View(model);
        }

        public IActionResult TenantEdit(int id)
        {
            Tenant model = tenantRepository.GetTenantById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult TenantEdit(Tenant model)
        {
            if (ModelState.IsValid)
            {
                tenantRepository.EditTenant(model);
                return RedirectToAction("TenantList");
            }
            return View(model);
        }

        public IActionResult TenantDelete(int id)
        {
            tenantRepository.DeleteTenant(new Tenant() { Id = id });
            return RedirectToAction("TenantList");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
