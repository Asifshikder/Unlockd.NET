using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Domain.Entities.Auth
{
   public class User : IdentityUser
    {
        public string FullName { get; set; }
        public int? CountryId { get; set; }
        public int? UserTypeId { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
        public virtual Country Country { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
