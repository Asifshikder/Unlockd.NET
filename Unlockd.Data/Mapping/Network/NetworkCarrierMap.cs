using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Data.Mapping.Network
{
   public class NetworkCarrierMap
    {
        public NetworkCarrierMap(EntityTypeBuilder<NetworkCarrier> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.NetworkName);
            builder.Property(t => t.CarrierIcon);
            builder.Property(t => t.BasePrice);
            builder.Property(t => t.CountryId);
        }
    }
}
