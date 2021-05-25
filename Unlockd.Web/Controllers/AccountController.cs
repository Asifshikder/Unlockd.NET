using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Auth;
using Unlockd.Web.Models;

namespace GS.WEB.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            if (signInManager.IsSignedIn(User) && !User.IsInRole("Admin"))
            {
                signInManager.SignOutAsync();
            }
            else if(signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
            {
                return Redirect("/Admin/Home/Index");
            }
            returnUrl = returnUrl.Replace("%2F", "/");
            LoginViewModel login = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
            if (result.Succeeded)
            {
                if (string.IsNullOrEmpty(login.ReturnUrl))
                {
                    return Redirect("/Manage/Home/Index");
                }
                return Redirect(login.ReturnUrl);
            }
            ModelState.AddModelError("IncorrectInput", "Username or Password is incorrect");
            return View(login);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout(User user)
        {
            if (signInManager.IsSignedIn(User))
            {
                await signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }
        private Task<User> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
    }
}
