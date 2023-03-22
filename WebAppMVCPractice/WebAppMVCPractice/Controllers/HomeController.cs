using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using WebAppMVCPractice.Models;

namespace WebAppMVCPractice.Controllers
{
    public class HomeController : Controller
    {
        Uri url = new Uri("https://localhost:44325/api");
        HttpClient client;

        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = url;
        }

        public ActionResult TenantList()
        {
            List<Tenant> list = new List<Tenant>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/TenantApi").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Tenant>>(data);
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult TenantBySurn(string surn)
        {
            List<Tenant> model = new List<Tenant>();
            Tenant tenant = new Tenant();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/TenantApi").Result;
            if ((response.IsSuccessStatusCode) && (surn != null))
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<List<Tenant>>(data);
                model = model.Where(x => x.Surn.Contains(surn)).ToList();
            }
            return View(model);
        }

        public ActionResult TenantCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TenantCreate(Tenant model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/TenantApi", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("TenantList");
            }
            return View();
        }

        public ActionResult TenantEdit(int id)
        {
            List<Tenant> model = new List<Tenant>();
            Tenant tenant = new Tenant();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/TenantApi").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<List<Tenant>>(data);
                tenant = model.Single(x => x.Id == id);
            }
            return View(tenant);
        }
        [HttpPost]
        public ActionResult TenantEdit(Tenant model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/TenantApi/" + model.Id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("TenantList");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult TenantDelete(int id)
        {
            Tenant tenant = new Tenant();
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/TenantApi/" + id).Result;
            return RedirectToAction("TenantList");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
