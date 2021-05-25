using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.CMS;

namespace Unlockd.Data.Mapping.CMS
{
   public class PageInfoMap
    {
        public PageInfoMap(EntityTypeBuilder<PageInfo>builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Slug);
            builder.Property(t => t.Url);
            builder.Property(t => t.PageName);
        }
    }
}
