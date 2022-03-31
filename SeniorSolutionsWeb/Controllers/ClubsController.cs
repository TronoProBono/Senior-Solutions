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
        /*
        public async Task<IActionResult> Index()
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
            return View(club);
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
        */
        public async Task<IActionResult> Index(int clubID, string? club_name, int location, string meeting_day, 
            int start_time_begin, int start_time_end, int end_time_begin, int end_time_end, int page_size,int? page)
        {

            var demi_Club = from Meet in _context.ClubMeeting
                                 join Location in _context.Locations on Meet.MeetingPlace equals Location.LocationId
                                 select new 
                                 { 
                                     ClubId = Meet.ClubId,
                                     LocationId = Location.LocationId,
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
                                LocationID = Meet.LocationId,
                                LocationName = Meet.LocationName,
                                MeetingDay = Meet.MeetingDay,
                                StartTime = Meet.StartTime,
                                EndTime = Meet.EndTime
                            };

            if (!(clubID < 0))
            {
                club = club = club.Where(s => s.ClubId!.Equals(clubID));
                if (club.Count() == 0)
                {
                    TempData["Error"] = "Club ID Not Valid";
                    return Redirect("/Clubs");
                }
            }

            if (!String.IsNullOrEmpty(club_name))
            {
                club = club.Where(s => s.ClubName!.Contains(club_name));
            }

            if (!(location < 0))
            {
                club = club.Where(s => s.LocationID!.Equals(location));
            }

            if (!String.IsNullOrEmpty(meeting_day))
            {
                club = club.Where(s => s.ClubName!.Contains(meeting_day));
            }
                        
            if (!(start_time_begin < 0) && !(end_time_begin < 0) && !(start_time_end < 0) && !(end_time_end < 0))
            {
                club = from cl in club
                       where (cl.StartTime >= start_time_begin && cl.StartTime <= start_time_end && cl.EndTime >= end_time_begin && cl.EndTime <= end_time_end)
                       select cl;
            }

            //Counts the amount of objects avalible in club
            var club_size = club.Count();
            //Controls how many clubs are displayed on a single page
            switch(page_size)
            {
                case 5:
                    page_size = 5;
                    break;
                case 10:
                    page_size = 10;
                    break;
                case 20:
                    page_size = 20;
                    break;
                case 25:
                    page_size = 25;
                    break;
                case 50:
                    page_size = 50;
                    break;
                default:
                    page_size = 25;
                    break;
            }
            if(page == null)
            {
                page = 0;
            }
            //Automaticly set the current page to the last page if the input is above the amount of objects or is set to -2
            if((page > Math.Abs(club_size-1)/page_size) || page == -2)
            {
                page = club_size / page_size;
                /*if (!((page-1 == club_size / page_size) && (club_size % page_size == 0)))
                {
                    page = club_size / page_size;
                }*/
            }
            /*if ((page == club_size / page_size) && (club_size % page_size == 0))
            {
                page--;
            }*/
            if(page < 0)
            { page = 0; }

            var startIndex = (int)(page*page_size);

            club = club.Skip(startIndex).Take(page_size);
            return View(await club.ToListAsync());
        }
    }
}
