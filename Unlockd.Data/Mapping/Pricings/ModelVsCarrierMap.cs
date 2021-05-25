using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Pricings;

namespace Unlockd.Data.Mapping.Pricings
{
   public class ModelVsCarrierMap
    {
        public ModelVsCarrierMap(EntityTypeBuilder<ModelVsCarrier> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.NetworkCarrierId);
            builder.Property(t => t.DeviceModelId);
            builder.Property(t => t.HasPremiumService);
            builder.Property(t => t.BasePrice);
            builder.Property(t => t.PremiumPrice);
            builder.Property(t => t.CreateBy);
            builder.Property(t => t.CreateDate);
            builder.HasOne(s => s.NetworkCarrier)
                .WithMany(s => s.ModelVsCarrier)
                .HasForeignKey(t => t.NetworkCarrierId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.ClientSetNull);

        }
    }
}
