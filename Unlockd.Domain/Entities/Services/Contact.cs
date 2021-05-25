using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Domain.Entities.Services
{
   public class Contact:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? CountryId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public virtual Country Country { get; set; }
    }
}
