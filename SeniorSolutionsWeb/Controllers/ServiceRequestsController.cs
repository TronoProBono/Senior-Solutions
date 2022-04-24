#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeniorSolutionsWeb.Data;
using SeniorSolutionsWeb.Models;

namespace SeniorSolutionsWeb.Controllers
{
    [Authorize]
    public class ServiceRequestsController : Controller
    {
        private readonly SeniorSolutionsWebContext _context;

        public ServiceRequestsController(SeniorSolutionsWebContext context)
        {
            _context = context;
        }

        // GET: ServiceRequests
        public async Task<IActionResult> Index(int? id)
        {
            var listOfRequests = await _context.ServiceRequest.ToListAsync();
            //var serviceRequest = listOfRequests.FindAll(m => m.RequestorId == id);
            return View(listOfRequests);
            //return View(await _context.ServiceRequest.ToListAsync());
        }

        // GET: ServiceRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            return View(serviceRequest);
        }

        // GET: ServiceRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("Id,Description")] ServiceRequest serviceRequest*/int ID, string Description)
        {
            ClaimsPrincipal _claim = User;
            var Id = 0;

            if (_claim != null)
            {
                foreach (Claim claim in _claim.Claims)
                {
                    Console.Write("CLAIM TYPE: {0} || CLAIM VALUE:{1}\n", claim.Type, claim.Value);
                    if (claim.Type == "residentId")
                    {
                        Id = Int32.Parse(claim.Value);
                    }
                }
            }

            var _request = new ServiceRequest();
            _request.Id = ID;
            _request.Description = Description;
            _request.RequestorId = Id;
            _request.EmployeeAssignedId = null;
            _request.CreationDate = DateTime.Now;
            _request.RequestorName = User.Identity.Name;
            _request.Status = "Waiting To Be Assigned";
            if (ModelState.IsValid)
            {
                _context.Add(_request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_request);
        }

        // GET: ServiceRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequest.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }
            return View(serviceRequest);
        }

        // POST: ServiceRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RequestorName,RequestorId,Description,Status,EmployeeAssignedId,CreationDate")] ServiceRequest serviceRequest)
        {
            if (id != serviceRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceRequestExists(serviceRequest.Id))
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
            return View(serviceRequest);
        }

        // GET: ServiceRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            return View(serviceRequest);
        }

        // POST: ServiceRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceRequest = await _context.ServiceRequest.FindAsync(id);
            _context.ServiceRequest.Remove(serviceRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceRequestExists(int id)
        {
            return _context.ServiceRequest.Any(e => e.Id == id);
        }
    }
}
