using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index()
        {
            var model = tenantRepository.GetTtenants();
            return View(model);
        }

        public IActionResult TenantEdit(int id) //создание+редактирование
        {
            Tenant model = id == default ? new Tenant() : tenantRepository.GetTenantById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult TenantEdit(Tenant model)
        {
            if (ModelState.IsValid)
            {
                tenantRepository.SaveTenant(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult TenantDelete(int id) //удаление
        {
            tenantRepository.DeleteTenant(new Tenant() { Id = id });
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
