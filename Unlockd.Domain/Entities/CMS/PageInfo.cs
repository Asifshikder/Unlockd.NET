using System;
using System.Collections.Generic;
using System.Text;

namespace Unlockd.Domain.Entities.CMS
{
   public class PageInfo:BaseEntity
    {
        public PageInfo()
        {
            PageContent = new HashSet<PageContent>();
        }
        public string Slug { get; set; }
        public string Url { get; set; }
        public string PageName { get; set; }
        public virtual ICollection<PageContent> PageContent { get; set; }
    }
}
