using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeniorSolutionsWeb.Data;

namespace SeniorSolutionsWeb.Controllers
{
    public class ClubsController : Controller
    {
        private readonly SeniorSolutionsWebContext _context;

        public static String AdditionByFour_15Min(int Initial, int Current, int Max, int Iteration, int Min)
        {
            if (Current == Initial)
            {
                Console.WriteLine("Initial:{0}\n", Initial);
                Console.WriteLine("Current:{0}\n", Current);
                Console.WriteLine("Max:{0}\n", Max);
                Console.WriteLine("Iteration:{0}\n", Iteration);
                Console.WriteLine("Min:{0}\n",Min);
                var AMPM = "AM";
                if (Current > 48)
                {
                    AMPM = "PM";
        }
                var hour = Iteration;
                if (Iteration > 13)
                {
                    hour = hour - 12;
                }
                switch (Iteration)
                {
                    case 0:
                        hour = 12;
                        break;
                    default:
                        break;
                }
                var Min_Correction = "00";
                if (Min != 0)
                {
                    Min_Correction = Min.ToString();
                }
                return hour + ":" + Min_Correction + " " + AMPM;
            }
            else if (Initial + 4 <= Max)
            {
                var result = AdditionByFour_15Min(Initial + 4, Current, Max, Iteration + 1, Min);
                if (result != "0")
                {
                    return result;
                }
            }
            return "0";
}

        public static String ConvertTime(int? Time)
        {
            if (Time == null)
            {
                throw new ArgumentNullException(nameof(Time));
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    var intro = AdditionByFour_15Min(i + 1, (int)Time, i + 93, 0, i * 15);
                    if (intro != "0")
                    {
                        return intro;
                    }
                }
            }
            return "Unknown";
        }

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
        public async Task<IActionResult> Index(int? clubID, string? club_name, int? location, string? meeting_day, 
            int? start_time_begin, int? start_time_end, int? end_time_begin, int? end_time_end, int? page_size,int? page)
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
                       join Meet in demi_Club on Club.ClubId equals Meet.ClubId into full_club
                       from Meet in full_club.DefaultIfEmpty()
                       select new
                       {
                           ClubId = /*Club == null ? -1 : */(Club.ClubId),
                           ClubName = /*Club == null ? string.Empty : */(Club.ClubName),
                           DateClubCreated = /*Club == null ? new DateTime(2020,5,1,0,0,0) :*/(Club.DateClubCreated),
                           LocationID = Meet.LocationId == null ? -1 : (Meet.LocationId),
                           LocationName = Meet.LocationName == null ? "" : (Meet.LocationName),
                           MeetingDay = Meet.MeetingDay == null ? "" : (Meet.MeetingDay),
                           StartTime = Meet.StartTime == null ? -1 : (Meet.StartTime),
                           EndTime = Meet.EndTime == null ? -1 : (Meet.EndTime)

                       };

            
            if (!(clubID < 0) && clubID != null)
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

            if ((location != null) && (location >= 0))
            {
                club = club.Where(s => s.LocationID!.Equals(location));
            }

            if (!String.IsNullOrEmpty(meeting_day))
            {
                club = club.Where(s => s.ClubName!.Contains(meeting_day));
            }
                        
            if ((start_time_begin != null) && (end_time_begin != null) && (start_time_end != null) && (end_time_end != null) && !(start_time_begin < 0) && !(end_time_begin < 0) && !(start_time_end < 0) && !(end_time_end < 0))
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
            //Automaticly set the current page to the last page if the input is above the amount of objects or of page is set to -2
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

            //Any page input below 0 (but not -2) will be set to the first page
            if(page < 0)
            { page = 0; }

            var filter_club = from orgin in club
                              select new
                              {
                                  clubID = orgin.ClubId
                              };

            filter_club = filter_club.Distinct();
            var startIndex = (int)(page*page_size);

            //club = club.Skip(startIndex).Take((int)page_size);
            filter_club = filter_club.Skip(startIndex).Take((int)page_size);
            club = from c1 in club
                   from c2 in filter_club
                   where c1.ClubId == c2.clubID
                   select c1;

            var exit_club = from prev in club
                            select new Models.ClubViewModel
                            {
                                ClubId = prev.ClubId,
                                ClubName = prev.ClubName,
                                DateClubCreated = prev.DateClubCreated,
                                LocationName = prev.LocationName,
                                MeetingDay = prev.MeetingDay,
                                StartTime = ConvertTime(prev.StartTime),
                                EndTime = ConvertTime(prev.EndTime),
                            };
            return View(await exit_club.ToListAsync());
        }
    }
}
