using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Domain.Entities.Services
{
   public class OurInfo : BaseEntity
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
