using eTicaret.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using eTicaret.Application.DTOs.Users;

namespace eTicaret.Mvc.Controllers
{
    [Route("account")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View(new UserRegistrationDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var userDto = await _userService.RegisterUserAsync(model);

                if (userDto != null)
                {
                    TempData["SuccessMessage"] = "Registration successful! Please log in.";

                    return RedirectToAction("Login");
                }

                ModelState.AddModelError("", "Registration failed. Please try again.");

                return View(model);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }


        [Route("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
