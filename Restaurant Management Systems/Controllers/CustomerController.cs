using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_Systems.Models;
using Restaurant_Management_Systems.Services;

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
                    HttpContext.Session.SetInt32("RoleId", roleId.Value);
                    HttpContext.Session.SetString("UserLoggedIn", "true");
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginModel);
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
