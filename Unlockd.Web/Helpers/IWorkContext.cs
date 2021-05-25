using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unlockd.Domain.Entities.Auth;

namespace Unlockd.Web.Helpers
{
    public interface IWorkContext
    {
        Task<User> GetCurrentUserAsync();
    }
}
