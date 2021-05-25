using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Device;

namespace Unlockd.Data.Mapping.Device
{
    public class DeviceModelMap
    {
        public DeviceModelMap(EntityTypeBuilder<DeviceModel> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name);
            builder.Property(t => t.Image);
            builder.Property(t => t.IsFeatured);
            builder.Property(t => t.Charge);
            builder.Property(t => t.BrandId);
            builder.HasOne(s => s.Brand)
                .WithMany(s => s.DeviceModel)
                .HasForeignKey(t => t.BrandId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.ClientSetNull);
        }
    }
}
