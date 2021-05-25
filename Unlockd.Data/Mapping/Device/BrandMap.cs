using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Device;

namespace Unlockd.Data.Mapping.Device
{
   public class BrandMap
    {
        public BrandMap(EntityTypeBuilder<Brand>builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t =>t.Name);
            builder.Property(t =>t.BrandLogo);
            builder.Property(t => t.IsFeatured);
            builder.Property(t =>t.FeaturedImage);
            builder.Property(t =>t.ShortDescription);
            builder.Property(t =>t.AverageUnlockingPrice);
        }
    }
}
