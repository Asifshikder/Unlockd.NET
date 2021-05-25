using System;
using System.Collections.Generic;
using System.Text;

namespace Unlockd.Domain.Entities.Blog
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string ShortDesciption { get; set; }
        public string Description { get; set; }
        public string PrimaryImage { get; set; }
        public int BlogCategoryId { get; set; }
        public bool IsFeatured { get; set; } = false;
        public virtual BlogCategory BlogCategory { get; set; }
    }
}
