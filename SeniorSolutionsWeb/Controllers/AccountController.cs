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
            if(resident != null) //Username does exist in resident DB
            {
                if (username == resident.Email && HashPassword(password) == resident.Password)
                {
                    claims.Add(new Claim("username", resident.Email));
                    claims.Add(new Claim("residentId", resident.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, resident.Email));
                    claims.Add(new Claim(ClaimTypes.Name, resident.FirstName + resident.LastName));
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
                    claims.Add(new Claim(ClaimTypes.Name, employee.FirstName + employee.LastName));
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

        [Authorize(Roles = "Manager")]
        public IActionResult Secured()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
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
