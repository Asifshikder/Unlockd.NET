using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.CMS;

namespace Unlockd.Data.Mapping.CMS
{
   public class PageContentMap
    {
        public PageContentMap(EntityTypeBuilder<PageContent>builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.RawHtmlCode);
            builder.Property(t => t.PageTitle);
            builder.Property(t => t.PageInfoId);
            builder.HasOne(s => s.PageInfo)
               .WithMany(s => s.PageContent).HasForeignKey(a => a.PageInfoId)
               .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.ClientSetNull);
        }
    }
}
