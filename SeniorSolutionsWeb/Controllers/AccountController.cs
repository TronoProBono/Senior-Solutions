using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SeniorSolutionsWeb.Data;
using Microsoft.EntityFrameworkCore;
using SeniorSolutionsWeb.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace SeniorSolutionsWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly SeniorSolutionsWebContext _context;

        public AccountController(SeniorSolutionsWebContext context)
        {
            _context = context;
        }
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public IActionResult YourClubs()
        {
            ClaimsPrincipal _claim = User;
            var ID = 0;
            if (_claim != null)
            {
                foreach (Claim claim in _claim.Claims)
                {
                    Console.Write("CLAIM TYPE: {0} || CLAIM VALUE:{1}\n", claim.Type, claim.Value);
                    if (claim.Type == "residentId")
                    {
                        ID = Int32.Parse(claim.Value);
                        break;
                    }
                }
                var club = from found in _context.ClubMembership
                           where found.ResidentID == ID
                           select new
                           {
                               RID = ID,
                               CID = found.ClubId,
                               RoleID = found.RoleID
                           };
                var _club = from c1 in club
                            from c2 in _context.Club
                            where c1.CID == c2.ClubId
                            select new
                            {
                                RID = c1.RID,
                                CID = c1.CID,
                                RoleID = c1.RoleID,
                                CName = c2.ClubName
                            };
                var exit_club = from prev in _context.ClubRoles
                                from unite in club
                                where prev.RoleID == unite.RoleID
                                select new Models.ClubRoles
                                {
                                    RoleID = unite.RoleID,
                                    ClubId = prev.ClubId,
                                    RoleRank = prev.RoleRank,
                                    RoleEval = prev.RoleEval,
                                    RoleName = prev.RoleName
                                };
                var view_model = from c1 in _club
                                 from _exit in exit_club
                                 where c1.RoleID == _exit.RoleID
                                 select new Models.ClubRoleViewModel
                                 {
                                     ClubId = _exit.ClubId,
                                     ClubName = c1.CName,
                                     RoleName = _exit.RoleName,
                                     RolePerms = _exit.RoleEval
                                 };
                return View(view_model);
            }
            return View();
        }
        public IActionResult Invites()
        {
            var _invite = from inv in _context.Invite
                         where inv.ResidentID == GetUser()
                         select inv;
            var club_name = from c1 in _invite
                            join c2 in _context.Club on c1.ClubID equals c2.ClubId
                            select new
                            {
                                ID = c1.ID,
                                RID = c1.ResidentID,
                                CID = c1.ClubID,
                                RoleID = c1.RoleID,
                                CName = c2.ClubName
                            };
            var club_role_name = from c1 in club_name
                                 from c2 in _context.ClubRoles
                                 where c1.RoleID == c2.RoleID
                                 select new
                                 {
                                     ID = c1.ID,
                                     RID = c1.RID,
                                     CID = c1.CID,
                                     RoleID = c1.RoleID,
                                     CName = c1.CName,
                                     RoleName = c2.RoleName
                                 };

            var event_name = from c1 in _invite
                             from c2 in _context.Events
                             where c1.EventID == c2.Id
                             select new
                             {
                                 ID = c1.ID,
                                 RID = c1.ResidentID,
                                 EID = c1.EventID,
                                 RoleID = c1.EventRoleID,
                                 EName = c2.Title
                             };
            var evnt_role_name = from c1 in event_name
                                 from c2 in _context.EventRoles
                                 where c1.EID == c2.EventId
                                 select new
                                 {
                                     ID = c1.ID,
                                     RID = c1.RID,
                                     EID = c1.EID,
                                     RoleID = c1.RID,
                                     EName = c1.EName,
                                     EventRoleName = c2.RoleName
                                 };
            var left_invite = from c1 in evnt_role_name
                              join c2 in club_role_name on c1.ID equals c2.ID into club_role
                              from c2 in club_role.DefaultIfEmpty()
                              select new InviteViewModel
                              {
                                  ID = c1.ID,
                                  ResidentID = c1.RID,
                                  ClubID = c2.CID,
                                  ClubName = c2.CName,
                                  RoleID = c2.RoleID,
                                  RoleName = c2.RoleName,
                                  EventID = c1.EID,
                                  EventName = c1.EName,
                                  EventRoleID = c1.RoleID,
                                  EventRoleName = c1.EventRoleName
                         };

            var right_invite = from c1 in club_role_name
                               join c2 in evnt_role_name on c1.ID equals c2.ID into club_role
                               from c2 in club_role.DefaultIfEmpty()
                               select new InviteViewModel
                               {
                                   ID = c1.ID,
                                   ResidentID = c1.RID,
                                   ClubID = c1.CID,
                                   ClubName = c1.CName,
                                   RoleID = c1.RoleID,
                                   RoleName = c1.RoleName,
                                   EventID = c2.EID,
                                   EventName = c2.EName,
                                   EventRoleID = c2.RoleID,
                                   EventRoleName = c2.EventRoleName
                               };

            var new_invite = left_invite.Concat(right_invite);
            var invite = new_invite.GroupBy(x => x.ID).Select(y => y.First());

            return View(invite);
        }

        [HttpPost,ActionName("Accept")]
        public async Task<IActionResult> Invites(int ID)
        {
            var get_invide =  _context.Invite.Where(m => m.ResidentID == GetUser());
            var _get_invide = get_invide.FirstOrDefault(m => m.ID == ID);
            if(_get_invide != null)
            {
                _context.Remove(_get_invide);
                if(_get_invide.ClubID != null && _get_invide.RoleID != null)
                {
                    ClubMembership refined = new ClubMembership();
                    refined.CID = (int)_get_invide.ClubID;
                    refined.RoleID = (int)_get_invide.RoleID;
                    refined.ResidentID = (int)_get_invide.ResidentID;
                    _context.ClubMembership.Add(refined);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("YourClubs");
                }
                else if (_get_invide.EventID != null && _get_invide.EventRoleID != null)
                {
                    EventMembership refined = new EventMembership();
                    refined.EventID = (int)_get_invide.EventID;
                    refined.RoleID = (int)_get_invide.EventRoleID;
                    refined.ResidentID = _get_invide.ResidentID;
                    _context.EventMembership.Add(refined);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("YourEvents");

                }
            }
            return RedirectToAction("Secured");
        }
        [HttpPost]
        public async Task<IActionResult> Decline(int ID)
        {
            var get_invide = _context.Invite.Where(m => m.ResidentID == GetUser());
            var _get_invide = get_invide.FirstOrDefault(m => m.ID == ID);
            if (_get_invide != null)
            {
                _context.Invite.Remove(_get_invide);
                await _context.SaveChangesAsync();
                return RedirectToAction("Invites");
            }
            return RedirectToAction("Secured");
        }

        public IActionResult YourEvents()
        {
            ClaimsPrincipal _claim = User;
            var ID = 0;
            if (_claim != null)
            {
                foreach (Claim claim in _claim.Claims)
                {
                    Console.Write("CLAIM TYPE: {0} || CLAIM VALUE:{1}\n", claim.Type, claim.Value);
                    if (claim.Type == "residentId")
                    {
                        ID = Int32.Parse(claim.Value);
                        break;
                    }
                }
                var club = from found in _context.EventMembership
                           where found.ResidentID == ID
                           select new
                           {
                               RID = ID,
                               EID = found.EventID,
                               RoleID = found.RoleID
                           };
                var _club = from c1 in club
                            from c2 in _context.Events
                            where c1.EID == c2.Id && c2.Date > DateTime.Now
                            select new
                            {
                                RID = c1.RID,
                                EID = c1.EID,
                                RoleID = c1.RoleID,
                                EName = c2.Title
                            };
                var exit_club = from prev in _context.EventRoles
                                from unite in club
                                where prev.EventRoleID == unite.RoleID
                                select new Models.EventRoles
                                {
                                    EventRoleID = unite.RoleID,
                                    EventId = prev.EventId,
                                    RoleRank = prev.RoleRank,
                                    RoleEval = prev.RoleEval,
                                    RoleName = prev.RoleName
                                };
                var view_model = from c1 in _club
                                 from _exit in exit_club
                                 where c1.RoleID == _exit.EventRoleID
                                 select new Models.ClubRoleViewModel
                                 {
                                     ClubId = _exit.EventId,
                                     ClubName = c1.EName,
                                     RoleName = _exit.RoleName,
                                     RolePerms = _exit.RoleEval
                                 };
                return View(view_model);
            }
            return View();
        }


        public IActionResult Settings()
        {
            ClaimsPrincipal _claim = User;
            var ID = 0;
            if (_claim != null)
            {
                foreach (Claim claim in _claim.Claims)
                {
                    Console.Write("CLAIM TYPE: {0} || CLAIM VALUE:{1}\n", claim.Type, claim.Value);
                    if (claim.Type == "residentId")
                    {
                        ID = Int32.Parse(claim.Value);
                        break;
                    }
                }
                var resident = from res in _context.Resident
                               where res.Id == ID
                               select res;
                //ViewData["Error"] = "LOL";
                return View(resident);
            }
            return View();
        }

        [HttpPost, ActionName("Update_Email")]
        public async Task<ActionResult> Settings(string re_email)
        {
            ClaimsPrincipal _claim = User;
            var ID = 0;
            if (_claim != null)
            {
                foreach (Claim claim in _claim.Claims)
                {
                    Console.Write("CLAIM TYPE: {0} || CLAIM VALUE:{1}\n", claim.Type, claim.Value);
                    if (claim.Type == "residentId")
                    {
                        ID = Int32.Parse(claim.Value);
                        break;
                    }
                }
                Resident resident = await _context.Resident
                .FirstOrDefaultAsync(m => m.Id == ID);

                if (ModelState.IsValid)
                {
                    var look_email = from ai in _context.Resident
                                     where ai.Email == re_email
                                     select ai;
                    if (look_email.Count() == 0)
                    {
                        resident.Email = re_email;
                        _context.Resident.Update(resident);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return RedirectToAction("Settings");
                    }
                }
            }
            return RedirectToAction("Secured");
        }

        [HttpPost, ActionName("Update_Password")]
        public async Task<ActionResult> Settings(string re_c_password, string re_password)
        {
            ClaimsPrincipal _claim = User;
            var ID = 0;
            if (_claim != null)
            {
                foreach (Claim claim in _claim.Claims)
                {
                    Console.Write("CLAIM TYPE: {0} || CLAIM VALUE:{1}\n", claim.Type, claim.Value);
                    if (claim.Type == "residentId")
                    {
                        ID = Int32.Parse(claim.Value);
                        break;
                    }
                }
                Resident resident = await _context.Resident
                .FirstOrDefaultAsync(m => m.Id == ID);

                if (ModelState.IsValid)
                {
                    if (resident.Password == HashPassword(re_c_password))
                    {
                        resident.Password = HashPassword(re_password);
                        _context.Resident.Update(resident);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Secured");
                    }
                }
            }
            return RedirectToAction("Settings");
        }



        /// <summary>
        /// Pulls user login data from the database and allows the login form
        /// to compare input data to the database for authentication/authorization.
        /// Cookie scheme is used.
        /// </summary>
        /// <param name="username">The unique username used for login.</param>
        /// <param name="password"></param>
        /// <param name="returnUrl">Url to return to if the user has to authenticate.</param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> ValidateUser(string username, string password, string? returnUrl)
        {
            var help = HashPassword("1324");
            Console.WriteLine("---------------------------Pass:{0} ||\n\n", help);
            ViewData["ReturnUrl"] = returnUrl;
            Resident? resident = await _context.Resident.FirstOrDefaultAsync(m => m.Email == username);
            Employee? employee = await _context.Employee.FirstOrDefaultAsync(m => m.Email == username);
              var claims = new List<Claim>();

            if (resident == null && employee == null) // Username entered doesn't exist in any database
            {
                TempData["Error"] = "Username or password is invalid.";
                return View("Login");
            }
            if (resident != null) //Username does exist in resident DB
            {
                if (username == resident.Email && HashPassword(password) == resident.Password)
                {
                    claims.Add(new Claim("username", resident.Email));
                    //claims.Add(new Claim("residentId", resident.Id.ToString()));
                    claims.Add(new Claim("residentId", resident.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, resident.Email));
                    claims.Add(new Claim(ClaimTypes.Name, resident.FirstName + " " + resident.LastName));
                    claims.Add(new Claim(ClaimTypes.Role, "Resident"));
                }
            }
            else //Username exists in employee DB
            {
                var mail = employee.Email;
                Console.WriteLine("---------------------------Email:{0}\n\n", mail);
                if (username == employee.Email && HashPassword(password) == employee.Password)
                {
                    claims.Add(new Claim("username", employee.Email));
                    claims.Add(new Claim("residentId", (-1).ToString())); // Unusual way, but this will work for checking if user
                                                                          // is an employee since, residentId is PK and never negative
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, employee.Email));
                    claims.Add(new Claim(ClaimTypes.Name, employee.FirstName + " " + employee.LastName));
                    if (employee.Position != null) claims.Add(new Claim(ClaimTypes.Role, employee.Position));
                }
            }

            if (claims.Count == 0) //Password was not correct, make sure NOT to sign them in
            {
                claims = null;
                TempData["Error"] = "Username or password is invalid.";
                return View("Login");
            }
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);
            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect("/Home");
            }

        }

        [Authorize]
        public async Task<IActionResult> LogoutUser()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [Authorize(Roles = "Resident")]
        public IActionResult Secured()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public int? GetUser()
        {
            ClaimsPrincipal _claim = User;
            var ID = 0;
            if (_claim != null)
            {
                foreach (Claim claim in _claim.Claims)
                {
                    Console.Write("CLAIM TYPE: {0} || CLAIM VALUE:{1}\n", claim.Type, claim.Value);
                    if (claim.Type == "residentId")
                    {
                        ID = Int32.Parse(claim.Value);
                        return ID;
                    }
                }
            }
            return null;
        }
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashedPassword;
        }
    }
}
