using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeniorSolutionsWeb.Data;

namespace SeniorSolutionsWeb.Controllers
{
    public class ClubsController : Controller
    {
        private readonly SeniorSolutionsWebContext _context;

        public ClubsController(SeniorSolutionsWebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int clubID)
        {

            var club = from Club in _context.Club
                       where Club.ClubId == clubID
                       select Club;
            if (club.Count() == 0)
            {
                TempData["Error"] = "Club ID Not Valid";
                return Redirect("/Clubs");
            }
            else
            {
                return View(club);
            }

            //return View(await _context.Club.ToListAsync());
        }

        public async Task<IActionResult> Index(string club_name, int location, string meeting_day, int start_time, int end_time)
        {

            var demi_Club = from Meet in _context.ClubMeeting
                                 join Location in _context.Locations on Meet.MeetingPlace equals Location.LocationId
                                 select new 
                                 { 
                                     ClubId = Meet.ClubId, 
                                     LocationName = Location.LocationName, 
                                     MeetingDay = Meet.MeetingDay, 
                                     StartTime = Meet.StartTime, 
                                     EndTime = Meet.EndTime
                                 };
            var club = from Club in _context.Club
                            join Meet in demi_Club on Club.ClubId equals Meet.ClubId
                            select new
                            {
                                ClubId = Club.ClubId,
                                ClubName = Club.ClubName,
                                DateClubCreated = Club.DateClubCreated,
                                LocationName = Meet.LocationName,
                                MeetingDay = Meet.MeetingDay,
                                StartTime = Meet.StartTime,
                                EndTime = Meet.EndTime
                            };

            if (!String.IsNullOrEmpty(club_name))
            {
                club = club.Where(s => s.ClubName!.Contains(club_name));
            }

            if (!(location < 0))
            {
                club = club.Where(s => s.!.Contains(location));
            }

            if (!String.IsNullOrEmpty(meeting_day))
            {
                club = club.Where(s => s.ClubName!.Contains(meeting_day));
            }
                        
            if (!(start_time < 0) && !(end_time < 0))
            {
                club = club.Where(s => s.);
            }

            return View(await _context.Club.ToListAsync());
        }
    }
}
