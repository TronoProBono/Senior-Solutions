using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SeniorSolutionsWeb.Data;
using Microsoft.EntityFrameworkCore;
using SeniorSolutionsWeb.Models;

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
            ViewData["ReturnUrl"] = returnUrl;
            var resident = await _context.Resident.FirstOrDefaultAsync(m => m.Email == username);
            var employee = await _context.Employee.FirstOrDefaultAsync(m => m.Email == username);
            var claims = new List<Claim>();
            if (resident == null)
            {
                TempData["Error"] = "Username or password is invalid.";
                return View("Login");
            }
            if (username == resident.Email && resident.HashPassword(password) == resident.Password)
            {
                
                claims.Add(new Claim("username", resident.Email));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, resident.Email));
                claims.Add(new Claim(ClaimTypes.Name, resident.FirstName + resident.LastName));
                //claims.Add(new Claim(ClaimTypes.Role, "SuperAdmin")); This should be for staff only
            }
            //if (username == employee.Email && employee.HashPassword(password) == employee.Password) //Should be for staff
            //{

            //    claims.Add(new Claim("username", employee.Email));
            //    claims.Add(new Claim(ClaimTypes.NameIdentifier, employee.Email));
            //    claims.Add(new Claim(ClaimTypes.Name, employee.FirstName + employee.LastName));
            //    //claims.Add(new Claim(ClaimTypes.Role, "SuperAdmin")); This should be for staff only
            //}

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
            TempData["Error"] = "Username or password is invalid.";
            return View("Login");
        }

        [Authorize] 
        public async Task<IActionResult> LogoutUser()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Secured()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
