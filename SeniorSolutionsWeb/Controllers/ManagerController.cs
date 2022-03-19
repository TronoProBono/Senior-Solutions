using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SeniorSolutionsWeb.Controllers
{
    [Authorize(Roles="Manager")]
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
        public IActionResult Transportation()
        {
            return View();
        }

        public IActionResult clubs()
        {
            return View();
        }

        public IActionResult events()
        {
            return View();
        }

        public IActionResult create_clubs()
        {
            return View();
        }

        public IActionResult create_events()
        {
            return View();
        }

        public IActionResult post()
        {
            return View();
        }

        public IActionResult Manage_Accounts()
        {
            return View();
        }

    }
}
