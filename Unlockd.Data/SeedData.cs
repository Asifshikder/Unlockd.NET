using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Auth;

namespace Unlockd.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string admin, string adminPw)
        {
            using (var context = new UnlockdContext(
                serviceProvider.GetRequiredService<DbContextOptions<UnlockdContext>>()))
            {
                var adminID = await EnsureUser(serviceProvider, admin, adminPw);
                await EnsureRole(serviceProvider, adminID, "Admin");
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string UserName, string UserPw)
        {
            var userManager = serviceProvider.GetService<UserManager<User>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new User
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, UserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<User>>();

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
    }
}
