using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Unlockd.Domain.Entities.Auth;

namespace Unlockd.Web.Helpers
{
    public class WorkContext : IWorkContext
    {

        private User _currentUser;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private HttpContext _httpContext;
        private readonly IConfiguration _configuration;

        public WorkContext(UserManager<User> userManager, SignInManager<User> signInManager,
                           IHttpContextAccessor contextAccessor,
                           IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContext = contextAccessor.HttpContext;
            _configuration = configuration;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            if (_currentUser != null)
            {
                return _currentUser;
            }

            var contextUser = _httpContext.User;
            _currentUser = await _userManager.GetUserAsync(contextUser);

            if (_currentUser != null)
            {
                return _currentUser;
            }

            //var userGuid = GetUserGuidFromCookies();
            ////if (userGuid.HasValue)
            ////{
            ////    _currentUser = _userRepository.Query().Include(x => x.Roles).FirstOrDefault(x => x.UserGuid == userGuid);
            ////}

            if (_currentUser != null && await _userManager.IsInRoleAsync(_currentUser,"Guest")) 
            {
                return _currentUser;
            }

          var  userGuid = Guid.NewGuid();
            var dummyEmail = string.Format("{0}@guest.unlockd.com", userGuid);
            _currentUser = new User
            {
                FullName = "Guest",
                Email = dummyEmail,
                UserName = dummyEmail,
            };
            var abc = await _userManager.CreateAsync(_currentUser, "User@123");
            return _currentUser;
        }

      

    }
}
