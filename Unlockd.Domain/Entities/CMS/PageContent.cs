using System;
using System.Collections.Generic;
using System.Text;

namespace Unlockd.Domain.Entities.CMS
{
   public class PageContent:BaseEntity
    {
        public PageContent()
        {
            Media = new HashSet<Media>();
        }
        public string RawHtmlCode { get; set; }
        public string PageTitle { get; set; }
        public int PageInfoId { get; set; }
        public virtual ICollection<Media> Media  { get; set; }
        public virtual PageInfo PageInfo{ get; set; }
    }
}
