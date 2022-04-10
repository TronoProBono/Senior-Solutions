using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeniorSolutionsWeb.Data;
using SeniorSolutionsWeb.Models;
using System.Diagnostics;

namespace SeniorSolutionsWeb.Controllers
{
    [Authorize]
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
            modelCollection.Votes = await _context.PollVote.ToListAsync();
            var orientations = _context.Orientations.ToList();
            var oDate = (from orientation in orientations where orientation.Date >= DateTime.Now orderby orientation.Date select orientation).Take(1).First();
            ViewData["NextOrientationDate"] = oDate.Date;
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

        //[HttpPost("Poll")]
        public async Task<IActionResult> Poll(string id, string vote, int residentId)
        {
            int ID = int.Parse(id);
            Poll? poll = await _context.Poll.FindAsync(ID);
            PollVote? pollVote = await _context.PollVote.SingleOrDefaultAsync(p => p.ResidentId == residentId);

            if(pollVote == null)
            {
                if (vote == poll.Answer)
                {
                    poll.Answer1Votes++;
                }else if (vote == poll.Answer2)
                {
                    poll.Answer2Votes++;
                }else if (vote == poll.Answer3)
                {
                    poll.Answer3Votes++;
                }else if (vote == poll.Answer4)
                {
                    poll.Answer4Votes++;
                }
                pollVote = new PollVote();
                pollVote.VotedFor = vote;
                pollVote.PollId = ID;
                pollVote.ResidentId = residentId; 
                _context.PollVote.Add(pollVote);
                _context.Poll.Update(poll);

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}