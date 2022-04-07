using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeniorSolutionsWeb.Data;
using SeniorSolutionsWeb.Models;
using System.Diagnostics;

namespace SeniorSolutionsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SeniorSolutionsWebContext _context;


        public HomeController(ILogger<HomeController> logger, SeniorSolutionsWebContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel modelCollection = new HomeViewModel();
            modelCollection.CommunityIssues = await _context.CommunityIssue.ToListAsync();
            modelCollection.Polls = await _context.Poll.ToListAsync();
            return View(modelCollection);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}