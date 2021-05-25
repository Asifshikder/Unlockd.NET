using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Network;

namespace Unlockd.Data.Mapping.Network
{
   public class CountryMap
    {
       public CountryMap (EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name);
            builder.Property(t => t.DisplayName);
            builder.Property(t => t.FlagIcon);
            builder.Property(t => t.Currency);
        }
    }
}
