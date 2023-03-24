using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using ClassLibrary;
using WebAppMVCPractice.Repository;

namespace WebAppMVCPractice.Controllers
{
    public class HomeController : Controller
    {
        ITestRepository testRepository;

        public HomeController(ITestRepository r)
        {
            testRepository = r;
        }

        public ActionResult TenantList()
        {
            return View(testRepository.GetTenants());
        }

        [HttpGet]
        public ActionResult TenantBySurn(string surn)
        {
            return View(testRepository.GetTenantBySurn(surn));
        }

        public ActionResult TenantCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TenantCreate(Tenant entity)
        {
            HttpResponseMessage response = testRepository.CreateTenant(entity);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("TenantList");
            }
            return View();
        }

        public ActionResult TenantEdit(Guid id)
        {
            return View(testRepository.EditTenant(id));
        }
        [HttpPost]
        public ActionResult TenantEdit(Tenant entity)
        {
            HttpResponseMessage response = testRepository.EditTenantPost(entity);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("TenantList");
            }
            return View(entity);
        }

        [HttpPost]
        public ActionResult TenantDelete(Guid id)
        {
            HttpResponseMessage response = testRepository.DeleteTenant(id);
            return RedirectToAction("TenantList");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
