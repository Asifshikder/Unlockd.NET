using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Pricings;

namespace Unlockd.Data.Mapping.Pricings
{
   public class CarrierCheckMap
    {
        public CarrierCheckMap(EntityTypeBuilder<CarrierCheck> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.BrandId);
            builder.Property(t => t.Price);
            builder.Property(t => t.CreateBy);
            builder.Property(t => t.CreateDate);
            builder.HasOne(s => s.Brand)
                .WithMany(s => s.CarrierCheck)
                .HasForeignKey(t => t.BrandId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.ClientSetNull);
        }
    }
}
