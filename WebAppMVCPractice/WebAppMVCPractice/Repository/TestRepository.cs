using System.Net.Http;
using System;
using ClassLibrary;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace WebAppMVCPractice.Repository
{
    public class TestRepository : ITestRepository
    {
        Uri url = new Uri("https://localhost:44325/api");
        HttpClient client;

        public TestRepository()
        {
            client = new HttpClient();
            client.BaseAddress = url;
        }

        public List<Tenant> GetTenants()
        {
            List<Tenant> list = new List<Tenant>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/TenantApi").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Tenant>>(data);
            }
            return list;
        }

        public List<Tenant> GetTenantBySurn(string surn)
        {
            List<Tenant> list;
            string data;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/TenantApi").Result;
            if ((response.IsSuccessStatusCode) && (surn != null))
            {
                data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Tenant>>(data);
                list = list.Where(x => x.Surn.Contains(surn)).ToList();
            }
            else
            {
                data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Tenant>>(data);
            }
            return list;
        }

        public HttpResponseMessage CreateTenant(Tenant entity)
        {
            string data = JsonConvert.SerializeObject(entity);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/TenantApi", content).Result;
            return (response);
        }

        public Tenant EditTenant(Guid id)
        {
            List<Tenant> list = new List<Tenant>();
            Tenant tenant = new Tenant();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/TenantApi").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Tenant>>(data);
                tenant = list.Single(x => x.Id == id);
            }
            return (tenant);
        }
        public HttpResponseMessage EditTenantPost(Tenant entity)
        {
            string data = JsonConvert.SerializeObject(entity);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/TenantApi/" + entity.Id, content).Result;
            return (response);
        }

        public HttpResponseMessage DeleteTenant(Guid id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/TenantApi/" + id).Result;
            return (response);
        }
    }
}
