using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Blog;

namespace Unlockd.Data.Mapping.Blog
{
   public class BlogPostMap
    {
        public BlogPostMap(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title);
            builder.Property(t => t.Description);
            builder.Property(t => t.PrimaryImage);
            builder.Property(t => t.BlogCategoryId);
            builder.Property(t => t.IsFeatured);
            builder.HasOne(t => t.BlogCategory)
                .WithMany(s=>s.BlogPost).HasForeignKey(t=>t.BlogCategoryId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.ClientSetNull);
        }
    }
}
