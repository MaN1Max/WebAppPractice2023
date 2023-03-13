using Microsoft.AspNetCore.Mvc;
using WebAppPractice2023.Data.Interfaces;
using WebAppPractice2023.ViewModels;

namespace WebAppPractice2023.Controllers
{
    public class TenantsController : Controller
    {
        private readonly ITenants _tenants;

        public TenantsController(ITenants itenants)
        {
            _tenants = itenants;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с арендаторами";
            TenantsIndexViewModel viewModel = new TenantsIndexViewModel();
            viewModel.AllTenants = _tenants.GetAllTenants;
            return View(viewModel);
        }
    }
}
