using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Data.Mapping.Services
{
   public class OurInfoMap
    {
        public OurInfoMap(EntityTypeBuilder<OurInfo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Address);
            builder.Property(t => t.CreateBy);
            builder.Property(t => t.CreateDate);
            builder.Property(t => t.Email);
            builder.Property(t => t.Phone);
            builder.Property(t => t.Status);
        }
    }
}
