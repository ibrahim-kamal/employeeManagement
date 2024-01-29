using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<Models.ApplicationUser> userManager;
        private readonly SignInManager<Models.ApplicationUser> signInManager;

        public AccountController(UserManager<Models.ApplicationUser> userManager , SignInManager<Models.ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid) {
                var user = new Models.ApplicationUser
                {
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email,
                };
                var result = await userManager.CreateAsync(user,registerViewModel.Password);
                if (result.Succeeded) {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
                return View(registerViewModel);
        }




        [HttpGet]
        [Route("login")]
        public IActionResult login()
        {
            return View();
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login(LoginViewModel model , string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {

                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    //await signInManager.SignInAsync(user, model.RememberMe);
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    
                    if (result.Succeeded) {
                        if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl)) {
                            return Redirect(ReturnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "User name and password invalide");
            }
            return View(model);
        }

        [HttpGet]
        [Route("logout")]
        [Authorize]
        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
