using Microsoft.AspNetCore.Mvc;

namespace SeniorSolutionsWeb.Controllers
{
    public class ClubsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
