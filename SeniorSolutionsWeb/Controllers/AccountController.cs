using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SeniorSolutionsWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnUrl)
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
            if (username == "admin" && password == "adminDEVenv")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                claims.Add(new Claim(ClaimTypes.Name, "John Doe"));
                claims.Add(new Claim(ClaimTypes.Role, "SuperAdmin"));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                } else
                {
                    return Redirect("/Home");
                }
                
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
