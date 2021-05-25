using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.CMS;

namespace Unlockd.Data.Mapping.CMS
{
   public class MediaMap
    {
        public MediaMap(EntityTypeBuilder<Media>builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.FileName);
            builder.Property(t => t.Thumbnail);
            builder.Property(t => t.FileUrl);
            builder.HasOne(s => s.PageContent)
                .WithMany(s => s.Media).HasForeignKey(a => a.PageContentId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.ClientSetNull);
        }
    }
}
