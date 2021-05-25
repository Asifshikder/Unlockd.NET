using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Auth;
using Unlockd.Service.Interface.Network;

namespace Unlockd.Web.Helpers
{
    public class LogService : ILogService
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private SignInManager<User> signInManager;
        private ICountryService countryService;
        private IHttpContextAccessor httpContextAccessor;

        public LogService(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager,
            ICountryService countryService, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.countryService = countryService;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task CreateAndSignInGuest()
        {
            var usercount = userManager.Users.Count();
            var nextuser = (usercount + 1).ToString();
            var username = "guest" + nextuser + "@veeunlock.com";
            var password = "unlock1234";
            var country = countryService.AllAsList().FirstOrDefault();
            User user = new User();
            user.FullName = username;
            user.Email = username;
            user.UserName = username;
            user.CountryId = country.Id;
          var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                 await signInManager.SignInAsync(user, false);
            }
        }

      
        public int SetAndGetCountryId(int id,User user)
        {
            user.CountryId = id;
            var res = userManager.UpdateAsync(user);
            if (res.IsCompletedSuccessfully)
            {
                return id;
            }
            else
            {
                return user.CountryId.Value;
            }
        }

    }
}
