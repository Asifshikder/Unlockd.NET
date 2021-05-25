using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Device;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Domain.Entities.SEOEntities
{
   public class SEO : BaseEntity
    {
        public SEO()
        {
            Keywords = new HashSet<Keyword>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
    }
}
