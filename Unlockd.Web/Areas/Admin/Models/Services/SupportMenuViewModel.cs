using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unlockd.Web.Areas.Admin.Models.Services
{
    public class SupportMenuViewModel
    {
        public int Id { get; set; }
        public string MenuIcon { get; set; }
        public IFormFile MenuIconFile { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsIncluded { get; set; }
    }
}
