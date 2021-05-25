using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Blog;

namespace Unlockd.Data.Mapping.Blog
{
   public class BlogCategoryMap
    {
        public BlogCategoryMap(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name);
        }
    }
}
