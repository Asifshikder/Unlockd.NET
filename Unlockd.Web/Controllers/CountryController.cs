using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Auth;

namespace Unlockd.Web.Controllers
{
    [Authorize]
    public class CountryController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public CountryController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<JsonResult> SetCountry(int id)
        {
            int countryId = 0;
            if (signInManager.IsSignedIn(User))
            {
                var user = GetCurrentUser().Result;
                user.CountryId = id;
                var res = await userManager.UpdateAsync(user);
                return Json(true);
            }
            else
            {
                var usercount = userManager.Users.Count();
                var nextuser = (usercount + 1).ToString();
                var username = "guest" + nextuser;
                var email = username + "@veeunlock.com";
                var password = "unlock1234";
                User user = new User();
                user.FullName = "Guest User";
                user.Email = email;
                user.UserName = username;
                user.CountryId =id;
                var result =await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    var findUser =await  userManager.FindByEmailAsync(email);
                    var resulta =await signInManager.PasswordSignInAsync(findUser, password, false, false);
                    if (resulta.Succeeded)
                    {
                        countryId = findUser.CountryId.Value;
                    }

                }
                return Json(true);
            }


        }
        public int GetCountry()
        {
            var user = GetCurrentUser();
            return user.Result.CountryId.Value;
        }

        private async Task<User> GetCurrentUser()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            return user;
        }
    }
}
