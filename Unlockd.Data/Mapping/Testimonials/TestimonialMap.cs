using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Blog;
using Unlockd.Domain.Entities.Testimonials;

namespace Unlockd.Data.Mapping.Testimonials
{
   public class TestimonialMap
    {
        public TestimonialMap(EntityTypeBuilder<Testimonial> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name);
            builder.Property(t => t.Title);
            builder.Property(t => t.Company);
            builder.Property(t => t.Message);
        }
    }
}
