using Microsoft.AspNetCore.Mvc;

namespace SeniorSolutionsWeb.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Schedule()
        {
            return View();
        }
        public IActionResult Tranportation()
        {
            return View();
        }

    }
}
