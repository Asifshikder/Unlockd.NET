using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Data.Mapping.Services
{
   public class SupportMenuMap
    {
        public SupportMenuMap(EntityTypeBuilder<SupportMenu> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name);
            builder.Property(t => t.MenuIcon);
            builder.Property(t => t.Description);
            builder.Property(t => t.IsIncluded);
            builder.Property(t => t.CreateBy);
            builder.Property(t => t.CreateDate);

        }
    }
}
