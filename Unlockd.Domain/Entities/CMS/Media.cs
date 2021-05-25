using System;
using System.Collections.Generic;
using System.Text;

namespace Unlockd.Domain.Entities.CMS
{
    public class Media : BaseEntity
    {
        public string FileName { get; set; }
        public string Thumbnail { get; set; }
        public string FileUrl { get; set; }
        public int PageContentId { get; set; }
        public virtual PageContent PageContent { get; set; }
    }
}
