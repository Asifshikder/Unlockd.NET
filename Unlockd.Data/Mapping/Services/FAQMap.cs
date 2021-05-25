using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Unlockd.Domain.Entities.Services;

namespace Unlockd.Data.Mapping.Services
{
    public class FAQMap
    {
        public FAQMap(EntityTypeBuilder<FAQ> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Question);
            builder.Property(t => t.Answer);
            builder.Property(t => t.CreateBy);
            builder.Property(t => t.CreateDate);
        }
    }
}
