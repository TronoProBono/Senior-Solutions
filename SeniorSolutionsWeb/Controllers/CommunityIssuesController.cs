#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeniorSolutionsWeb.Data;
using SeniorSolutionsWeb.Models;

namespace SeniorSolutionsWeb.Views
{
    public class CommunityIssuesController : Controller
    {
        private readonly SeniorSolutionsWebContext _context;

        public CommunityIssuesController(SeniorSolutionsWebContext context)
        {
            _context = context;
        }

        // GET: CommunityIssues
        public async Task<IActionResult> Index()
        {
            return View(await _context.CommunityIssue.ToListAsync());
        }

        public async Task<IActionResult> Vote(int id, int residentId, string opinion)
        {
            if(ModelState.IsValid)
            {
                var hasVoted = _context.CommunityIssueVote.FirstOrDefault(vote => vote.CommunityIssueId == id && vote.ResidentId == residentId);
                if (hasVoted != null) return RedirectToAction(nameof(Index));
                //Find out if resident has voted on this before, if they have then kick them outta here
                var communityIssue = await _context.CommunityIssue.FindAsync(id);
                
                if(opinion == "positive")
                {
                    communityIssue.UpVotes++;
                } else
                {
                    communityIssue.UpVotes--;
                }
                var newVote = new CommunityIssueVote();
                newVote.CommunityIssueId = id;
                newVote.ResidentId = residentId;
                _context.CommunityIssueVote.Add(newVote);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // GET: CommunityIssues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communityIssue = await _context.CommunityIssue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (communityIssue == null)
            {
                return NotFound();
            }
            ViewData["listOfReplies"] = _context.CommunityIssueReplies.Where(reply => reply.CommunityIssueID == id).ToList();
            return View(communityIssue);
        }

        // GET: CommunityIssues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommunityIssues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CreatedDate,UpVotes,DownVotes,ResidentId")] CommunityIssue communityIssue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(communityIssue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(communityIssue);
        }

        // GET: CommunityIssues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communityIssue = await _context.CommunityIssue.FindAsync(id);
            if (communityIssue == null)
            {
                return NotFound();
            }
            return View(communityIssue);
        }

        // POST: CommunityIssues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CreatedDate,UpVotes,DownVotes")] CommunityIssue communityIssue)
        {
            if (id != communityIssue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(communityIssue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommunityIssueExists(communityIssue.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(communityIssue);
        }

        // GET: CommunityIssues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var communityIssue = await _context.CommunityIssue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (communityIssue == null)
            {
                return NotFound();
            }

            return View(communityIssue);
        }

        // POST: CommunityIssues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var communityIssue = await _context.CommunityIssue.FindAsync(id);
            _context.CommunityIssue.Remove(communityIssue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommunityIssueExists(int id)
        {
            return _context.CommunityIssue.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ResidentResponse(int IssueID, int residentID,string residentName, string response)
        {
            var reply = new CommunityIssueReply();
            reply.CommunityIssueID = IssueID;
            reply.ResidentID = residentID;
            reply.Response = response;
            reply.ResidentName = residentName;
            _context.CommunityIssueReplies.Add(reply);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
    }
}
