using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_Systems.Models;

namespace Restaurant_Management_Systems.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Login()
        {
            LoginModel loginModel = new LoginModel();
            loginModel.UsernamesEnabled = true;
            return View(loginModel);
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                return new RedirectToRouteResult("Homepage", null);
            }
            return Login();
        }

        public IActionResult Register()
        {
            RegisterModel registerModel = new RegisterModel();
            registerModel.UsernamesEnabled = true;
            return View(registerModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                return new RedirectToRouteResult("Homepage", null);
            }
            return Login();
        }

    }
}
