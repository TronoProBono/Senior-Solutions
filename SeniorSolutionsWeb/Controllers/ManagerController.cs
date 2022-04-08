using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeniorSolutionsWeb.Data;
using SeniorSolutionsWeb.Models;

namespace SeniorSolutionsWeb.Controllers
{
    [Authorize(Roles="Manager")]
    public class ManagerController : Controller
    {
        private readonly SeniorSolutionsWebContext _context;

        public ManagerController(SeniorSolutionsWebContext context)
        {
            _context = context;
        }
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

        public IActionResult Poll()
        {
            return View();
        }
        
        public async Task<IActionResult> CreatePoll([Bind("Question, Answer, Answer2, Answer3, Answer4")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Poll", poll);
        }

        public IActionResult Manage_Accounts()
        {
            return View();
        }

    }
}
