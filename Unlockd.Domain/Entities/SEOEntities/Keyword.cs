using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Domain.Entities.SEOEntities
{
   public class Keyword : BaseEntity
    {
        public string Name { get; set; }
        public int SEOId { get; set; }
        public SEO SEO { get; set; }
    }
}
