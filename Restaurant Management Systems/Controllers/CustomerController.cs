using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_Systems.Models;
using Restaurant_Management_Systems.Services;
using System.Security.Claims;

namespace Restaurant_Management_Systems.Controllers
{
    public class CustomerController : Controller
    {
        #region Fields

        ICustomerService _customerService;

        #endregion

        #region Ctor

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #endregion

        #region Methods

        #region Login
        
        public IActionResult Login()
        {
            LoginModel loginModel = new LoginModel();
            loginModel.UsernamesEnabled = true;
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (loginModel?.UsernamesEnabled == true)
            {
                ModelState.Remove(nameof(LoginModel.Email));
            }
            if (ModelState.IsValid)
            {
                var roleId = await _customerService.GetUserRoleIdAsync(loginModel);
                if (roleId.HasValue && roleId > 0)
                {
                    var roleName = MapRoleName(roleId.Value);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, loginModel.UsernamesEnabled ? loginModel.Username ?? string.Empty : loginModel.Email ?? string.Empty),
                        new Claim("RoleId", roleId.Value.ToString()),
                        new Claim(ClaimTypes.Role, roleName)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = loginModel.RememberMe,
                        ExpiresUtc = loginModel.RememberMe ? DateTimeOffset.UtcNow.AddDays(7) : DateTimeOffset.UtcNow.AddHours(1),
                        AllowRefresh = true
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

                    HttpContext.Session.SetInt32("RoleId", roleId.Value);
                    HttpContext.Session.SetString("UserLoggedIn", "true");

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid username/email or password.");
            }
            return View(loginModel);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
                return RedirectToAction("Login", "Customer");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Customer");
        }

        private string MapRoleName(int roleId)
        {
            return roleId switch
            {
                1 => "Admin",
                2 => "Manager",
                3 => "Customer",
                _ => "User"
            };
        }

        #endregion

        #region Register

        public IActionResult Register()
        {
            RegisterModel registerModel = new RegisterModel();
            registerModel.UsernamesEnabled = true;
            return View(registerModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterModel registerModel)
        {
            if (registerModel?.UsernamesEnabled == true)
            {
                ModelState.Remove(nameof(RegisterModel.Email));
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(registerModel);
        }

        #endregion

        #endregion
    }
}
