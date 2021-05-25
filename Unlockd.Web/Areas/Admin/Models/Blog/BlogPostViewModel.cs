using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unlockd.Web.Areas.Admin.Models.Blog
{
    public class BlogPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  PrimaryImage { get; set; }
        public IFormFile   PrimaryImageFile { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
