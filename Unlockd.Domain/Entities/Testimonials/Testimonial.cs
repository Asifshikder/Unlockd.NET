using System;
using System.Collections.Generic;
using System.Text;

namespace Unlockd.Domain.Entities.Testimonials
{
   public class Testimonial : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Message { get; set; }
        
    }
}
