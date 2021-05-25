using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Auth;

namespace Unlockd.Web.Helpers
{
    public interface ILogService
    {
        public Task CreateAndSignInGuest();
        public int SetAndGetCountryId(int id,User user);
    }
}
